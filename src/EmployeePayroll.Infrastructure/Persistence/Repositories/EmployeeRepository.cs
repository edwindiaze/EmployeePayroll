using EmployeePayroll.Application.Exceptions;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Interfaces;
using EmployeePayroll.Infrastructure.Persistence.Contexts;

namespace EmployeePayroll.Infrastructure.Persistence.Repositories;

public class EmployeeRepository(PayrollDbContext dbContext) : BaseRepository<Employee>(dbContext), IEmployeeRepository
{
    public async Task<Employee> GetByEmailAsync(string email)
    {
        var employees = await GetAllAsync(e => e.Email == email);
        var employee = employees.SingleOrDefault()
            ?? throw new AppException($"Employee with email '{email}' not found.");
        return employee;
    }
}
