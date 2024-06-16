using EmployeePayroll.Application.Employees.DTOs;
using MediatR;

namespace EmployeePayroll.Application.Employees.Queries;

public record GetEmployeeByEmailQuery(string Email) : IRequest<EmployeeDto?>;
