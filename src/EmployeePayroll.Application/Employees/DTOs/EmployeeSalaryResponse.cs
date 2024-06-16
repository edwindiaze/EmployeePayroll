using EmployeePayroll.Domain.Enums;

namespace EmployeePayroll.Application.Employees.DTOs;

public class EmployeeSalaryResponse
{
    public string FullName { get; init; } = string.Empty;
    public EmployeeTypes EmployeeType { get; init; }
    public int WorkedHours { get; init; }
    public decimal HourlyRate { get; init; }
    public decimal TotalSalary { get; init; }
}
