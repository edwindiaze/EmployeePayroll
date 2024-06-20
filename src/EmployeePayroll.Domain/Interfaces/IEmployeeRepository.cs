using EmployeePayroll.Domain.Entities;

namespace EmployeePayroll.Domain.Interfaces;

public interface IEmployeeRepository: IRepository<Employee>
{
    Task<Employee> GetByEmailAsync(string email);
}