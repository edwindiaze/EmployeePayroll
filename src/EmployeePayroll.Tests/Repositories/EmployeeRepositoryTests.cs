using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Interfaces;
using EmployeePayroll.Infrastructure.Persistence.Contexts;
using EmployeePayroll.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeePayroll.Tests.Repositories;
public class EmployeeRepositoryTests
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly InMemoryDbContext _dbContext;

    public EmployeeRepositoryTests()
    {
        // Create an instance of IConfiguration (e.g., using Microsoft.Extensions.Configuration)
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Create an instance of DbContextOptions<PayrollDbContext>
        var options = new DbContextOptionsBuilder<PayrollDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        _dbContext = new InMemoryDbContext(options, configuration);
        _employeeRepository = new InMemoryEmployeeRepository(_dbContext);

        // Seed data for the in-memory database (optional)
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnEmployee()
    {
        // Arrange
        var employee = new Employee {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _employeeRepository.GetByIdAsync(employee.Id);

        // Assert
        Assert.Equal(employee, result);
    }

    [Fact]
    public async Task GetByEmailAsync_ShouldReturnEmployeeWithSpecifiedEmail()
    {
        // Arrange
        string email = "john.doe@example.com";

        // Act
        var employee = await _employeeRepository.GetByEmailAsync(email);

        // Assert
        Assert.NotNull(employee);
        Assert.Equal(email, employee.Email);
    }
}
