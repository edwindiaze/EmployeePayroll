using AutoMapper;
using EmployeePayroll.Application.Exceptions;
using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Interfaces;

namespace EmployeePayroll.Infrastructure.Services;

public class DepartmentService(IDepartmentRepository repository, IMapper mapper) : IDepartmentService
{
    private readonly IDepartmentRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<Department> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Guid> CreateAsync(Department department)
    {
        // Perform additional validation or business logic if needed
        await _repository.CreateAsync(department);
        return department.Id;
    }

    public async Task UpdateAsync(Department department)
    {
        var existingDepartment = await _repository.GetByIdAsync(department.Id) 
            ?? throw new AppException($"Department with ID '{department.Id}' not found.");

        // Perform additional validation or business logic if needed
        _mapper.Map(department, existingDepartment);
        await _repository.UpdateAsync(existingDepartment);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existingDepartment = await _repository.GetByIdAsync(id) 
            ?? throw new AppException($"Department with ID '{id}' not found.");
        await _repository.DeleteAsync(existingDepartment.Id);
    }
}