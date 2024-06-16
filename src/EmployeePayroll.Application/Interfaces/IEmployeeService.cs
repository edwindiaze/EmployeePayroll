using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Domain.Entities;

namespace EmployeePayroll.Application.Interfaces;

public interface IEmployeeService
{
    Task<Employee> GetByIdAsync(Guid id);
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<EmployeeDto?> GetByEmailAsync(string email);
    Task<Guid> CreateAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Guid id);
    Task<IReadOnlyList<Employee>> SearchByAsync(string firstName, string lastName, int? age, int? workedHours);
    Task DeleteByEmailAsync(string email);
}