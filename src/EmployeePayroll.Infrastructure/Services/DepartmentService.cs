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

    public async Task<Department> GetDepartmentByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Guid> CreateDepartmentAsync(Department department)
    {
        // Perform additional validation or business logic if needed
        await _repository.AddAsync(department);
        return department.Id;
    }

    public async Task UpdateDepartmentAsync(Department department)
    {
        var existingDepartment = await _repository.GetByIdAsync(department.Id) 
            ?? throw new AppException($"Department with ID '{department.Id}' not found.");

        // Perform additional validation or business logic if needed
        _mapper.Map(department, existingDepartment);
        await _repository.UpdateAsync(existingDepartment);
    }

    public async Task DeleteDepartmentAsync(Guid id)
    {
        var existingDepartment = await _repository.GetByIdAsync(id) 
            ?? throw new AppException($"Department with ID '{id}' not found.");
        await _repository.DeleteAsync(existingDepartment.Id);
    }
}