using EmployeePayroll.Application.Departments.Commands;
using EmployeePayroll.Application.Interfaces;
using MediatR;

namespace EmployeePayroll.Application.Departments.Handlers;

public class DeleteDepartmentCommandHandler(IDepartmentService service) : IRequestHandler<DeleteDepartmentCommand>
{
    private readonly IDepartmentService _service = service;

    public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Id);
    }
}
