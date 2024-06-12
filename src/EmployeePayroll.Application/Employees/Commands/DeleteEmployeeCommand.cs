using MediatR;

namespace EmployeePayroll.Application.Employees.Commands;

public class DeleteEmployeeCommand : IRequest
{
    public Guid Id { get; set; }
}