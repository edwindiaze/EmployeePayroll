using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Application.Employees.Handlers;
using EmployeePayroll.Application.Employees.Queries;
using EmployeePayroll.Application.Interfaces;
using EmployeePayroll.Application.Mappings;
using EmployeePayroll.Domain.Interfaces;
using EmployeePayroll.Domain.Services;
using EmployeePayroll.Infrastructure.Persistence.Contexts;
using EmployeePayroll.Infrastructure.Persistence.Repositories;
using EmployeePayroll.Infrastructure.Services;
using EmployeePayroll.WebAPI.Filters;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeePayroll.WebAPI.Extensions;

public static class ServiceExtensions
{
    public static void AddWebApi(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<ValidationFilter>();
        });
    }

    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddDbContext<PayrollDbContext>(options =>
        options.UseNpgsql(ConfigService.GetConnectionString(configuration)));

        // Register command and query handlers
        services.AddTransient<IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>, GetEmployeesQueryHandler>();
        services.AddTransient<IRequestHandler<GetEmployeeQuery, EmployeeDto>, GetEmployeeQueryHandler>();

        // Register other services
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<ISalaryCalculator, StandardSalaryCalculatorService>();
    }
}
