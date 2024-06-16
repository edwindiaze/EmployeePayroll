using AutoMapper;
using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Application.Employees.Queries;
using EmployeePayroll.Application.Interfaces;
using MediatR;

namespace EmployeePayroll.Application.Employees.Handlers;

public class GetEmployeesQueryHandler(IEmployeeService service, IMapper mapper) 
    : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
{
    private readonly IEmployeeService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _service.GetAllAsync();
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }
}