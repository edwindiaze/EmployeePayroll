using EmployeePayroll.Application.Employees.DTOs;
using MediatR;

namespace EmployeePayroll.Application.Employees.Queries;

public class GetEmployeeQuery : IRequest<EmployeeDto>
{
    public Guid Id { get; set; }
}