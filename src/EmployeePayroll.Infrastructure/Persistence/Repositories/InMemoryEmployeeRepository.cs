using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Interfaces;
using EmployeePayroll.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeePayroll.Infrastructure.Persistence.Repositories;

public class InMemoryEmployeeRepository(InMemoryDbContext dbContext)
    : BaseRepository<Employee>(dbContext), IEmployeeRepository
{
    public async Task<Employee> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Email == email);
    }
}
