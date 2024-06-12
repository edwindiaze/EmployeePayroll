using EmployeePayroll.Domain.Entities;

namespace EmployeePayroll.Application.Interfaces;

public interface IDepartmentService
{
    Task<Department> GetDepartmentByIdAsync(Guid id);
    Task<IEnumerable<Department>> GetAllDepartmentsAsync();
    Task<Guid> CreateDepartmentAsync(Department department);
    Task UpdateDepartmentAsync(Department department);
    Task DeleteDepartmentAsync(Guid id);
}
