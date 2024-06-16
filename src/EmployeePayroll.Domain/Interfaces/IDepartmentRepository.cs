using EmployeePayroll.Domain.Entities;

namespace EmployeePayroll.Domain.Interfaces;

public interface IDepartmentRepository
{
    Task<Department> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Department>> GetAllAsync();
    Task Createsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(Guid id);
}