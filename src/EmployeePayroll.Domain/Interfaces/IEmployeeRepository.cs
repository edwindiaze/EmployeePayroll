using EmployeePayroll.Domain.Entities;
using System.Linq.Expressions;

namespace EmployeePayroll.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Employee>> SearchByAsync(Expression<Func<Employee, bool>>? predicate = null);
    Task CreateAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Guid id);
    Task<Employee> GetByEmailAsync(string email);
}