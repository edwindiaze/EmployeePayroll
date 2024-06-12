using EmployeePayroll.Application.Departments.DTOs;
using MediatR;

namespace EmployeePayroll.Application.Departments.Queries;

public class GetDepartmentQuery: IRequest<DepartmentDto>
{
    public Guid Id { get; set; }
}
