using EmployeePayroll.Domain.Enums;

namespace EmployeePayroll.Application.Employees.DTOs;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public int Age { get; set; }
    public int WorkedHours { get; set; }
    public decimal SalaryByHour { get; set; }
    public decimal Salary { get; set; }
    public EmployeeTypes EmployeeType { get; set; }
    public string? Email { get; set; }
    public Guid DepartmentId { get; set; }
}