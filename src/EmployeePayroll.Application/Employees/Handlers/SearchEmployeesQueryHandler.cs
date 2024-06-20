using EmployeePayroll.Application.Employees.Queries;
using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Domain.Entities;
using MediatR;

namespace EmployeePayroll.Application.Employees.Handlers;

public class SearchEmployeesQueryHandler : IRequestHandler<SearchEmployeesQuery, IEnumerable<Employee>>
{
    private readonly IEmployeeService _service;

    public SearchEmployeesQueryHandler(IEmployeeService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<Employee>> Handle(SearchEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await _service.SearchByAsync(
            request.FirstName,
            request.LastName,
            request.Age,
            request.WorkedHours
        );
    }
}
