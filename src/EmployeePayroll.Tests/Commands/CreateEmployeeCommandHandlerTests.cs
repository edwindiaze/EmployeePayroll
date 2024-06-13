using AutoMapper;
using EmployeePayroll.Application.Employees.Commands;
using EmployeePayroll.Application.Employees.Handlers;
using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Domain.Entities;
using NSubstitute;

namespace EmployeePayroll.Tests.Commands;

public class CreateEmployeeCommandHandlerTests
{
    private IEmployeeService _employeeServiceMock;
    private IMapper _mapperMock;
    private CreateEmployeeCommandHandler _handler;

    public CreateEmployeeCommandHandlerTests()
    {
        // Arrange
        _employeeServiceMock = Substitute.For<IEmployeeService>();
        _mapperMock = Substitute.For<IMapper>();
        _handler = new CreateEmployeeCommandHandler(_employeeServiceMock, _mapperMock);
    }

    [Fact]
    public async Task Handle_ShouldCreateEmployee_WhenValidRequest()
    {
        // Arrange
        var command = new CreateEmployeeCommand
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
        };

        var employeeId = Guid.NewGuid();
        var employee = new Employee
        {
            Id = employeeId,
            FirstName = command.FirstName,
            Email = command.Email,
        };

        _mapperMock.Map<Employee>(command).Returns(employee);
        _employeeServiceMock.CreateEmployeeAsync(employee).Returns(Task.FromResult(employeeId));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(employeeId, result);
        await _employeeServiceMock.Received().CreateEmployeeAsync(employee);
    }
}
