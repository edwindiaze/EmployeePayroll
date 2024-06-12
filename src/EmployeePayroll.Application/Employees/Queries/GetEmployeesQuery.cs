using EmployeePayroll.Application.Employees.DTOs;
using MediatR;

namespace EmployeePayroll.Application.Employees.Queries;

public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
{
}