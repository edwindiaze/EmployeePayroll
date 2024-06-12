using AutoMapper;
using EmployeePayroll.Application.Departments.DTOs;
using EmployeePayroll.Application.Departments.Queries;
using EmployeePayroll.Application.Interfaces;
using MediatR;

namespace EmployeePayroll.Application.Departments.Handlers;

public class GetDepartmentsQueryHandler(IDepartmentService service, IMapper mapper)
    : IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentDto>>
{
    private readonly IDepartmentService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<DepartmentDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await _service.GetAllDepartmentsAsync();
        return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
    }
}
