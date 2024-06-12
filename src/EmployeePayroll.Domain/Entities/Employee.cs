using EmployeePayroll.Domain.Enums;
using EmployeePayroll.Domain.ValueObjects;

namespace EmployeePayroll.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public FullName FullName => new(firstName: FirstName, lastName: LastName);
    public int Age { get; set; }
    public int WorkedHours { get; set; }
    public decimal SalaryByHour { get; set; }
    public EmployeeTypes EmployeeType { get; set; }
    public string? Email { get; set; }
    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }

    public decimal CalculateSalary()
    {
        decimal baseSalary = WorkedHours * SalaryByHour;

        return EmployeeType switch
        {
            EmployeeTypes.Associate => baseSalary,
            EmployeeTypes.Technical => baseSalary * 1.2m,// 20% increase
            EmployeeTypes.Senior => baseSalary * 1.5m,// 50% increase
            EmployeeTypes.Lead => baseSalary * 2m,// 100% increase
            _ => throw new ApplicationException($"Invalid employee type: {EmployeeType}"),
        };
    }
}
