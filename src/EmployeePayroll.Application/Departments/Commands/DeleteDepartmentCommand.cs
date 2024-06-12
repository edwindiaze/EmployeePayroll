using MediatR;

namespace EmployeePayroll.Application.Departments.Commands;

public class DeleteDepartmentCommand: IRequest
{
    public Guid Id { get; set; }
}
