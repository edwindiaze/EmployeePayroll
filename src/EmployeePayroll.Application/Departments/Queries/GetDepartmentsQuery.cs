using EmployeePayroll.Application.Departments.DTOs;
using MediatR;

namespace EmployeePayroll.Application.Departments.Queries;

public class GetDepartmentsQuery: IRequest<IEnumerable<DepartmentDto>>
{
}
