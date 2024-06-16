using EmployeePayroll.Application.Employees.Handlers;
using EmployeePayroll.Application.Employees.Queries;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Enums;
using EmployeePayroll.Domain.Interfaces;
using FluentAssertions;
using NSubstitute;

namespace EmployeePayroll.Tests.Application;

public class GetEmployeeSalaryQueryHandlerTests
{
    private readonly IEmployeeRepository _repository = Substitute.For<IEmployeeRepository>();
    private readonly ISalaryCalculator _calculator = Substitute.For<ISalaryCalculator>();
    private readonly GetEmployeeSalaryQueryHandler _handler;

    public GetEmployeeSalaryQueryHandlerTests()
    {
        _handler = new GetEmployeeSalaryQueryHandler(_repository, _calculator);
    }

    [Fact]
    public async Task Handle_WithValidEmail_ShouldReturnSalaryResponse()
    {
        // Arrange
        var email = "john@example.com";
        var employee = new Employee
        {
            FirstName = "John",
            LastName = "Doe",
            Email = email,
            EmployeeType = EmployeeTypes.Senior,
            WorkedHours = 40,
            SalaryByHours = 25
        };

        _repository.GetByEmailAsync(email).Returns(employee);
        _calculator.CalculateTotalSalary(employee).Returns(1200m);

        var query = new GetEmployeeSalaryQuery(email);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result!.FullName.Should().Be("John Doe");
        result.EmployeeType.Should().Be(EmployeeTypes.Senior);
        result.WorkedHours.Should().Be(40);
        result.HourlyRate.Should().Be(25);
        result.TotalSalary.Should().Be(1200);

        await _repository.Received(1).GetByEmailAsync(email);
        _calculator.Received(1).CalculateTotalSalary(employee);
    }

    [Fact]
    public async Task Handle_WithInvalidEmail_ShouldReturnNull()
    {
        // Arrange
        var email = "nonexistent@example.com";
        _repository.GetByEmailAsync(email).Returns((Employee?)null);

        var query = new GetEmployeeSalaryQuery(email);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
        await _repository.Received(1).GetByEmailAsync(email);
        _calculator.DidNotReceive();
    }

    [Fact]
    public async Task Handle_WithValidEmail_ShouldUseOptimizedRepositoryMethod()
    {
        // Arrange
        var email = "jane@example.com";
        var info = new Employee {
            FirstName = "Jane",
            LastName = "Doe",
            EmployeeType = EmployeeTypes.Lead,
            WorkedHours = 45,
            SalaryByHours = 30m
        };

        _repository.GetByEmailAsync(email).Returns(info);
        _calculator.CalculateTotalSalary(Arg.Any<Employee>()).Returns(1755m);

        var query = new GetEmployeeSalaryQuery(email);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result!.FullName.Should().Be("Jane Doe");
        result.EmployeeType.Should().Be(EmployeeTypes.Lead);
        result.WorkedHours.Should().Be(45);
        result.HourlyRate.Should().Be(30);
        result.TotalSalary.Should().Be(1755);

        await _repository.Received(1).GetByEmailAsync(email);
        await _repository.DidNotReceive().GetByEmailAsync(Arg.Any<string>());
        _calculator.Received(1).CalculateTotalSalary(Arg.Is<Employee>(e =>
            e.EmployeeType == EmployeeTypes.Lead &&
            e.WorkedHours == 45 &&
            e.SalaryByHours == 30m
        ));
    }
}
