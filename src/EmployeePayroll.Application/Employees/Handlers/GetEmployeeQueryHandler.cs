using AutoMapper;
using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Application.Employees.Queries;
using EmployeePayroll.Application.Interfaces;
using MediatR;

namespace EmployeePayroll.Application.Employees.Handlers;

public class GetEmployeeQueryHandler(IEmployeeService service, IMapper mapper) 
    : IRequestHandler<GetEmployeeQuery, EmployeeDto>
{
    private readonly IEmployeeService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = await _service.GetByIdAsync(request.Id);
        return _mapper.Map<EmployeeDto>(employee);
    }
}