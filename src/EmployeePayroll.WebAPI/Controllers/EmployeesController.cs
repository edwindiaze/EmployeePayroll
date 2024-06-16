using EmployeePayroll.Application.Employees.Commands;
using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Application.Employees.Queries;
using EmployeePayroll.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayroll.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetEmployeeQuery { Id = id };
            var employee = await _mediator.Send(query);
            return employee is null ? NotFound() : Ok(employee);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<Employee>> GetByEmail(string email)
        {
            var query = new GetEmployeeByEmailQuery(email);
            var employee = await _mediator.Send(query);
            return employee is null ? NotFound() : Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllEmployeesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("salary/{email}")]
        [ProducesResponseType(typeof(EmployeeSalaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeSalaryResponse>> GetSalary(string email)
        {
            var query = new GetEmployeeSalaryQuery(email);
            var response = await _mediator.Send(query);

            return response is null ? NotFound() : Ok(response);
        }

        // GET /api/employees/search?firstName=John&age=30
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(
        [FromQuery] string? firstName, [FromQuery] string? lastName,
        [FromQuery] int? age, [FromQuery] int? workedHours)
        {
            var query = new SearchEmployeesQuery(firstName, lastName, age, workedHours);
            var employees = await _mediator.Send(query);
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == command.Id)
            {
                await _mediator.Send(command);
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
