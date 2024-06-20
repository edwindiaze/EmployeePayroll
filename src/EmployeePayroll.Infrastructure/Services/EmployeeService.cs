using AutoMapper;
using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Application.Exceptions;
using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Extensions;
using EmployeePayroll.Domain.Interfaces;

namespace EmployeePayroll.Infrastructure.Services;

public class EmployeeService(IEmployeeRepository repository, IMapper mapper) : IEmployeeService
{
    private readonly IEmployeeRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<Employee> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Guid> CreateAsync(Employee employee)
    {
        Validate(employee);
        await _repository.CreateAsync(employee);
        return employee.Id;
    }

    public async Task UpdateAsync(Employee employee)
    {
        var existingEmployee = await _repository.GetByIdAsync(employee.Id) 
            ?? throw new AppException($"Employee with ID '{employee.Id}' not found.");

        _mapper.Map(employee, existingEmployee);
        
        Validate(existingEmployee);
        await _repository.UpdateAsync(existingEmployee);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existingEmployee = await _repository.GetByIdAsync(id) 
            ?? throw new AppException($"Employee with ID '{id}' not found.");
        await _repository.DeleteAsync(existingEmployee.Id);
    }

    public async Task<IReadOnlyList<Employee>> SearchByAsync(string? firstName, string? lastName, int? age, int? workedHours)
    {
        var employees = await _repository.GetAllAsync(e =>
            (string.IsNullOrWhiteSpace(firstName) || e.FirstName.Contains(firstName)) &&
            (string.IsNullOrWhiteSpace(lastName) || e.LastName.Contains(lastName)) &&
            (!age.HasValue || e.Age == age.Value) &&
            (!workedHours.HasValue || e.WorkedHours == workedHours.Value));

        return employees;
    }

    public async Task DeleteByEmailAsync(string email)
    {
        var employees = await _repository.GetAllAsync(e => e.Email == email);
        var employee = employees.SingleOrDefault()
            ?? throw new AppException($"Employee with email '{email}' not found.");
        await _repository.DeleteAsync(employee.Id);
    }

    public async Task<EmployeeDto?> GetByEmailAsync(string email)
    {
        var employees = await _repository.GetAllAsync(e => e.Email == email);
        var employee = employees.SingleOrDefault();
        return employee == null ? null : _mapper.Map<EmployeeDto>(employee);
    }

    private static void Validate(Employee employee)
    {
        var validationResult = employee.ValidateEmployee();
        if (validationResult.IsFailure)
        {
            throw new AppException(validationResult.Error);
        }
    }
}
