using EmployeePayroll.Application.Employees.Commands;
using EmployeePayroll.Application.Interfaces;
using MediatR;

namespace EmployeePayroll.Application.Employees.Handlers;

public class DeleteEmployeeCommandHandler(IEmployeeService service) : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeService _service = service;

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Id);
    }
}
