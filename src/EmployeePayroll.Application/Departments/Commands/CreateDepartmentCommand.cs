using MediatR;

namespace EmployeePayroll.Application.Departments.Commands;

public class CreateDepartmentCommand : IRequest<Guid>
{
    public string? Name { get; set; }
    public string? Address { get; set; }
}
