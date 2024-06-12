using AutoMapper;
using EmployeePayroll.Application.Departments.DTOs;
using EmployeePayroll.Application.Departments.Queries;
using EmployeePayroll.Application.Interfaces;
using MediatR;

namespace EmployeePayroll.Application.Departments.Handlers;

public class GetDepartmentQueryHandler(IDepartmentService service, IMapper mapper)
    : IRequestHandler<GetDepartmentQuery, DepartmentDto>
{
    private readonly IDepartmentService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<DepartmentDto> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
        var department = await _service.GetDepartmentByIdAsync(request.Id);
        return _mapper.Map<DepartmentDto>(department);
    }
}
