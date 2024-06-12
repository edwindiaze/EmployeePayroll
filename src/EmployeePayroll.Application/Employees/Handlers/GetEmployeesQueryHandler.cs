using AutoMapper;
using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Application.Employees.Queries;
using EmployeePayroll.Application.Interfaces;
using MediatR;

namespace EmployeePayroll.Application.Employees.Handlers;

public class GetEmployeesQueryHandler(IEmployeeService service, IMapper mapper) 
    : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
{
    private readonly IEmployeeService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _service.GetAllEmployeesAsync();
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }
}