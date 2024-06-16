using AutoMapper;
using EmployeePayroll.Application.Departments.Commands;
using EmployeePayroll.Application.Departments.DTOs;
using EmployeePayroll.Application.Employees.Commands;
using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Domain.Entities;

namespace EmployeePayroll.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName.Value))
            .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.GetBaseSalary()));

        CreateMap<CreateEmployeeCommand, Employee>();
        
        CreateMap<UpdateEmployeeCommand, Employee>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<Department, DepartmentDto>();
        CreateMap<CreateDepartmentCommand, Department>();
        CreateMap<UpdateDepartmentCommand, Department>();
    }
}