using AutoMapper;
using EmployeePayroll.Application.Employees.Commands;
using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Domain.Entities;
using MediatR;

namespace EmployeePayroll.Application.Employees.Handlers;

public class CreateEmployeeCommandHandler(IEmployeeService service, IMapper mapper) : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(request);
        await _service.CreateAsync(employee);
        return employee.Id;
    }
}