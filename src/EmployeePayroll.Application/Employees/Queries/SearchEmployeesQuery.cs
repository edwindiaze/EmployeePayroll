using EmployeePayroll.Domain.Entities;
using MediatR;

namespace EmployeePayroll.Application.Employees.Queries;

public record SearchEmployeesQuery(
        string? FirstName,
        string? LastName,
        int? Age,
        int? WorkedHours
    ) : IRequest<IEnumerable<Employee>>;