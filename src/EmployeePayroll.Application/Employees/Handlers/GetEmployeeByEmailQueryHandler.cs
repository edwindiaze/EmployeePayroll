using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Application.Employees.Queries;
using EmployeePayroll.Application.Interfaces;
using MediatR;

namespace EmployeePayroll.Application.Employees.Handlers;

public class GetEmployeeByEmailQueryHandler(IEmployeeService service) : IRequestHandler<GetEmployeeByEmailQuery, EmployeeDto?>
{
    private readonly IEmployeeService _service = service;

    public async Task<EmployeeDto?> Handle(GetEmployeeByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetByEmailAsync(request.Email);
    }
}
