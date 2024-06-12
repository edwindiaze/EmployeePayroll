using AutoMapper;
using EmployeePayroll.Application.Employees.Commands;
using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Domain.Entities;
using MediatR;

namespace EmployeePayroll.Application.Employees.Handlers;

public class UpdateEmployeeCommandHandler(IEmployeeService service, IMapper mapper) : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(request);
        await _service.UpdateEmployeeAsync(employee);
    }
}
