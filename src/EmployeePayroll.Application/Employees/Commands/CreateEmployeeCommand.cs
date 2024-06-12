using MediatR;
using EmployeePayroll.Domain.Enums;

namespace EmployeePayroll.Application.Employees.Commands;

public class CreateEmployeeCommand : IRequest<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public int WorkedHours { get; set; }
    public decimal SalaryByHour { get; set; }
    public EmployeeTypes EmployeeType { get; set; }
    public string? Email { get; set; }
    public Guid DepartmentId { get; set; }
}