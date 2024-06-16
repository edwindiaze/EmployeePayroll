using EmployeePayroll.Application.Employees.DTOs;
using MediatR;

namespace EmployeePayroll.Application.Employees.Queries;

public record GetEmployeeSalaryQuery(string Email) : IRequest<EmployeeSalaryResponse?>;