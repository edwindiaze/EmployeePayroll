using AutoMapper;
using EmployeePayroll.Application.Employees.Commands;
using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Domain.Entities;
using MediatR;

namespace EmployeePayroll.Application.Departments.Handlers;

public class CreateDepartmentCommandHandler(IDepartmentService service, IMapper mapper) : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IDepartmentService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var department = _mapper.Map<Department>(request);
        await _service.CreateAsync(department);
        return department.Id;
    }
}
