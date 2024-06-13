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
        var employee = new Employee { Id = employeeId, /* other properties */ };
        var expectedEmployeeDto = new EmployeeDto { Id = employeeId, /* other properties */ };

        _employeeRepository.GetByIdAsync(employeeId).Returns(employee);
        _mapper.Map<EmployeeDto>(employee).Returns(expectedEmployeeDto);

        // Act
        var result = await _employeeService.GetEmployeeByIdAsync(employeeId);

        // Assert
        Assert.Equal(employeeId, result.Id);
        await _employeeRepository.Received(1).GetByIdAsync(employeeId);
        _mapper.Received(1).Map<EmployeeDto>(employee);
    }
}
