using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Interfaces;
using EmployeePayroll.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeePayroll.Infrastructure.Persistence.Repositories;

public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<Employee> GetByIdAsync(Guid id) => await _dbContext.Employees.FindAsync(id);

    public async Task<IReadOnlyList<Employee>> GetAllAsync(Expression<Func<Employee, bool>> predicate = null)
    {
        IQueryable<Employee> query = _dbContext.Employees;

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.ToListAsync();
    }

    public async Task AddAsync(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        _dbContext.Employees.Update(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var employee = await _dbContext.Employees.FindAsync(id);
        if (employee != null)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
