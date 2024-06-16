using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Enums;
using EmployeePayroll.Domain.Services;
using FluentAssertions;
using NSubstitute;

namespace EmployeePayroll.Tests.Services;

public class StandardSalaryCalculatorServiceTests
{
    private readonly StandardSalaryCalculatorService _calculator = new();

    [Theory]
    [InlineData(EmployeeTypes.Associate, 1000, 1000)]
    [InlineData(EmployeeTypes.Technical, 1000, 1100)]
    [InlineData(EmployeeTypes.Senior, 1000, 1200)]
    [InlineData(EmployeeTypes.Lead, 1000, 1300)]
    public void CalculateTotalSalary_ShouldApplyCorrectMultiplier(EmployeeTypes type, decimal baseSalary, decimal expected)
    {
        // Arrange
        var employee = new Employee {
            FirstName = "John",
            LastName = "Doe",
            EmployeeType = type 
        };
        employee.GetBaseSalary().Returns(baseSalary);

        // Act
        var result = _calculator.CalculateTotalSalary(employee);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void CalculateTotalSalary_WithInvalidType_ShouldThrow()
    {
        // Arrange
        var employee = new Employee {
            FirstName = "John",
            LastName = "Doe",
            EmployeeType = (EmployeeTypes)99 
        };
        employee.GetBaseSalary().Returns(1000);

        // Act & Assert
        FluentActions.Invoking(() => _calculator.CalculateTotalSalary(employee))
            .Should().Throw<ArgumentOutOfRangeException>();
    }
}
