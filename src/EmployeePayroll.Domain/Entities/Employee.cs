using EmployeePayroll.Domain.Enums;
using EmployeePayroll.Domain.ValueObjects;

namespace EmployeePayroll.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public FullName FullName => new(firstName: FirstName, lastName: LastName);
    public int Age { get; set; }
    public int WorkedHours { get; set; }
    public decimal SalaryByHours { get; set; }
    public EmployeeTypes EmployeeType { get; set; }
    public string? Email { get; set; }
    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }

    public decimal GetBaseSalary()
    {
        decimal baseSalary = WorkedHours * SalaryByHours;
        return baseSalary;
    }
}
