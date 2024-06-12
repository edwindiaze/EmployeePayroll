using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Interfaces;
using EmployeePayroll.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeePayroll.Infrastructure.Persistence.Repositories;

public class DepartmentRepository(AppDbContext dbContext) : IDepartmentRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<Department> GetByIdAsync(Guid id) => await _dbContext.Departments.FindAsync(id);

    public async Task<IReadOnlyList<Department>> GetAllAsync()
    {
        return await _dbContext.Departments.ToListAsync();
    }

    public async Task AddAsync(Department Department)
    {
        await _dbContext.Departments.AddAsync(Department);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Department Department)
    {
        _dbContext.Departments.Update(Department);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var Department = await _dbContext.Departments.FindAsync(id);
        if (Department != null)
        {
            _dbContext.Departments.Remove(Department);
            await _dbContext.SaveChangesAsync();
        }
    }
}