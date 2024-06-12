using AutoMapper;
using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Application.Exceptions;
using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Enums;
using EmployeePayroll.Domain.Interfaces;

namespace EmployeePayroll.Infrastructure.Services;

public class EmployeeService(IEmployeeRepository repository, IMapper mapper) : IEmployeeService
{
    private readonly IEmployeeRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Guid> CreateEmployeeAsync(Employee employee)
    {
        ValidateEmployee(employee);
        await _repository.AddAsync(employee);
        return employee.Id;
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        var existingEmployee = await _repository.GetByIdAsync(employee.Id) 
            ?? throw new AppException($"Employee with ID '{employee.Id}' not found.");

        ValidateEmployee(employee);
        _mapper.Map(employee, existingEmployee);
        await _repository.UpdateAsync(existingEmployee);
    }

    public async Task DeleteEmployeeAsync(Guid id)
    {
        var existingEmployee = await _repository.GetByIdAsync(id) 
            ?? throw new AppException($"Employee with ID '{id}' not found.");
        await _repository.DeleteAsync(existingEmployee.Id);
    }

    public async Task<IReadOnlyList<Employee>> SearchEmployeesByCriteriaAsync(string firstName, string lastName, int? age, int? workedHours)
    {
        var employees = await _repository.GetAllAsync(e =>
            (string.IsNullOrWhiteSpace(firstName) || e.FirstName.Contains(firstName)) &&
            (string.IsNullOrWhiteSpace(lastName) || e.LastName.Contains(lastName)) &&
            (!age.HasValue || e.Age == age.Value) &&
            (!workedHours.HasValue || e.WorkedHours == workedHours.Value));

        return employees;
    }

    public async Task DeleteEmployeeByEmailAsync(string email)
    {
        var employees = await _repository.GetAllAsync(e => e.Email == email);
        var employee = employees.SingleOrDefault()
            ?? throw new AppException($"Employee with email '{email}' not found.");
        await _repository.DeleteAsync(employee.Id);
    }

    public async Task<EmployeeDto> GetEmployeeByEmailAsync(string email)
    {
        var employees = await _repository.GetAllAsync(e => e.Email == email);
        var employee = employees.SingleOrDefault();
        return employee == null ? null : _mapper.Map<EmployeeDto>(employee);
    }

    private static void ValidateEmployee(Employee employee)
    {
        if (string.IsNullOrWhiteSpace(employee.FirstName) || employee.FirstName.Length < 3 || employee.FirstName.Length > 20)
        {
            throw new AppException("First name must be between 3 and 20 characters.");
        }

        if (string.IsNullOrWhiteSpace(employee.LastName) || employee.LastName.Length < 3 || employee.LastName.Length > 30)
        {
            throw new AppException("Last name must be between 3 and 30 characters.");
        }

        if (employee.Age < 10)
        {
            throw new AppException("Age must be greater than 10.");
        }

        if (employee.WorkedHours < 30 || employee.WorkedHours > 50)
        {
            throw new AppException("Worked hours must be between 30 and 50.");
        }

        if (employee.SalaryByHour < 13)
        {
            throw new AppException("Salary by hour must be greater than 13.");
        }

        if (!Enum.IsDefined(typeof(EmployeeTypes), employee.EmployeeType))
        {
            throw new AppException("Invalid employee type.");
        }
    }
}
