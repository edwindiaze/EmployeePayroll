using EmployeePayroll.Domain.Entities;
using FluentAssertions;

namespace EmployeePayroll.Tests.Domain;

public class EmployeeTests
{
    [Theory]
    [InlineData(40, 25, 1000)]
    [InlineData(35, 20, 700)]
    [InlineData(0, 50, 0)]
    [InlineData(50, 0, 0)]
    public void GetBaseSalary_ShouldCalculateCorrectly(int hours, decimal rate, decimal expected)
    {
        // Arrange
        var employee = new Employee {
            FirstName = "Juan",
            LastName = "Valdez",
            WorkedHours = hours, 
            SalaryByHours = rate 
        };

        // Act
        var result = employee.GetBaseSalary();

        // Assert
        result.Should().Be(expected);
    }
}
