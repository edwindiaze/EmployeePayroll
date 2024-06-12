using AutoMapper;
using EmployeePayroll.Application.Departments.Commands;
using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Domain.Entities;
using MediatR;

namespace EmployeePayroll.Application.Departments.Handlers;

public class UpdateDepartmentCommandHandler(IDepartmentService service, IMapper mapper) : IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IDepartmentService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = _mapper.Map<Department>(request);
        await _service.UpdateDepartmentAsync(department);
    }
}
