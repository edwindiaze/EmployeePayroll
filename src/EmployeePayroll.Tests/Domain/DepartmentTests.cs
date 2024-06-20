using EmployeePayroll.Domain.Entities;

namespace EmployeePayroll.Tests.Domain;

public class DepartmentTests
{
    [Fact]
    public void Department_IdProperty_ShouldSetAndGetGuid()
    {
        // Given
        var department = new Department();
        var expectedId = Guid.NewGuid();

        // When
        department.Id = expectedId;

        // Then
        Assert.Equal(expectedId, department.Id);
    }

    [Fact]
    public void Department_NameProperty_ShouldSetAndGetString()
    {
        // Arrange
        var department = new Department();
        const string expectedName = "Marketing";

        // Act
        department.Name = expectedName;

        // Assert
        Assert.Equal(expectedName, department.Name);
    }

    [Fact]
    public void Department_AddressProperty_ShouldSetAndGetString()
    {
        // Arrange
        var department = new Department();
        const string expectedAddress = "123 Main St.";

        // Act
        department.Address = expectedAddress;

        // Assert
        Assert.Equal(expectedAddress, department.Address);
    }
}
