using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Domain.Entities;

namespace EmployeePayroll.Application.Interfaces;

public interface IEmployeeService
{
    Task<Employee> GetEmployeeByIdAsync(Guid id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByEmailAsync(string email);
    Task<Guid> CreateEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(Guid id);
    Task<IReadOnlyList<Employee>> SearchEmployeesByCriteriaAsync(string firstName, string lastName, int? age, int? workedHours);
    Task DeleteEmployeeByEmailAsync(string email);
}