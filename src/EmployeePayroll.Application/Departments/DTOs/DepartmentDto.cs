namespace EmployeePayroll.Application.Departments.DTOs;

public class DepartmentDto
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Address { get; private set; }
}