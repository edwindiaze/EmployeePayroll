using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Infrastructure.Persistence.Contexts;
using EmployeePayroll.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace EmployeePayroll.Tests.Repositories;
public class EmployeeRepositoryTests
{
    private AppDbContext _dbContext;
    private EmployeeRepository _employeeRepository;
    private IConfiguration _configurationMock;

    public EmployeeRepositoryTests()
    {
        //var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
        //    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        //    .Options;

        //_configurationMock = Substitute.For<IConfiguration>();
        //_dbContext = new AppDbContext(dbContextOptions, _configurationMock);
        //_employeeRepository = new EmployeeRepository(_dbContext);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnEmployee()
    {
        // Arrange
        var employee = new Employee { /* properties */ };
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _employeeRepository.GetByIdAsync(employee.Id);

        // Assert
        Assert.Equal(employee, result);
    }
}
