using AutoMapper;
using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Interfaces;
using EmployeePayroll.Infrastructure.Services;
using NSubstitute;

namespace EmployeePayroll.Tests.Services;

public class EmployeeServiceTests
{
    private IEmployeeRepository _employeeRepository;
    private IMapper _mapper;
    private EmployeeService _employeeService;

    public EmployeeServiceTests()
    {
        _employeeRepository = Substitute.For<IEmployeeRepository>();
        _mapper = Substitute.For<IMapper>();
        _employeeService = new EmployeeService(_employeeRepository, _mapper);
    }

    [Fact]
    public async Task GetEmployeeAsync_ShouldReturnEmployeeDto()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var employee = new Employee { 
            Id = employeeId,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };
        var expectedEmployeeDto = new EmployeeDto { 
            Id = employeeId,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };

        _employeeRepository.GetByIdAsync(employeeId).Returns(employee);
        _mapper.Map<EmployeeDto>(employee).Returns(expectedEmployeeDto);

        // Act
        var result = await _employeeService.GetByIdAsync(employeeId);

        // Assert
        Assert.Equal(employeeId, result.Id);
        await _employeeRepository.Received(1).GetByIdAsync(employeeId);
        _mapper.Received(1).Map<EmployeeDto>(employee);
    }
}
