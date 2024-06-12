using MediatR;

namespace EmployeePayroll.Application.Departments.Commands;

public class UpdateDepartmentCommand: IRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
}
