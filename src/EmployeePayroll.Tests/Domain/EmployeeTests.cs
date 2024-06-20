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
        // Given
        var employee = new Employee {
            FirstName = "John",
            LastName = "Doe",
            WorkedHours = hours, 
            SalaryByHour = rate 
        };

        // When
        var result = employee.GetBaseSalary();

        // Then
        result.Should().Be(expected);
    }
}
