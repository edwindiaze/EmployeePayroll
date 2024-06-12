using EmployeePayroll.Domain.Entities;

namespace EmployeePayroll.Domain.Interfaces;

public interface IDepartmentRepository
{
    Task<Department> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Department>> GetAllAsync();
    Task AddAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(Guid id);
}