using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Interfaces;
using EmployeePayroll.Infrastructure.Persistence.Contexts;

namespace EmployeePayroll.Infrastructure.Persistence.Repositories;

public class DepartmentRepository(PayrollDbContext dbContext) : BaseRepository<Department>(dbContext), IDepartmentRepository
{
}