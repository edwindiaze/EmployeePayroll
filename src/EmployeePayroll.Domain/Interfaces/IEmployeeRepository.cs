using EmployeePayroll.Domain.Entities;
using System.Linq.Expressions;

namespace EmployeePayroll.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Employee>> GetAllAsync(Expression<Func<Employee, bool>> predicate = null);
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Guid id);
}