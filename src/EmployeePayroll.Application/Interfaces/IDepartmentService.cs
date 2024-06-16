using EmployeePayroll.Domain.Entities;

namespace EmployeePayroll.Application.Interfaces;

public interface IDepartmentService
{
    Task<Department> GetByIdAsync(Guid id);
    Task<IEnumerable<Department>> GetAllAsync();
    Task<Guid> CreateAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(Guid id);
}
