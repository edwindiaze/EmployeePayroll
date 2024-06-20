using EmployeePayroll.Application.Employees.DTOs;
using EmployeePayroll.Application.Employees.Queries;
using EmployeePayroll.Domain.Interfaces;
using MediatR;

namespace EmployeePayroll.Application.Employees.Handlers;

public class GetEmployeeSalaryQueryHandler : IRequestHandler<GetEmployeeSalaryQuery, EmployeeSalaryResponse?>
{
    private readonly IEmployeeRepository _repository;
    private readonly ISalaryCalculator _calculator;

    public GetEmployeeSalaryQueryHandler(IEmployeeRepository repository, ISalaryCalculator calculator)
        => (_repository, _calculator) = (repository, calculator);

    public async Task<EmployeeSalaryResponse?> Handle(GetEmployeeSalaryQuery request, CancellationToken cancellationToken)
    {
        var email = (request.Email ?? string.Empty).ToLower();
        var employee = await _repository.GetByEmailAsync(email);
        if (employee == null) return null;

        var totalSalary = _calculator.CalculateTotalSalary(employee);
        var fullName = employee.FullName == null ? string.Empty : employee.FullName.ToString();

        return new EmployeeSalaryResponse
        {
            FullName = fullName,
            EmployeeType = employee.EmployeeType,
            WorkedHours = employee.WorkedHours,
            HourlyRate = employee.SalaryByHour,
            TotalSalary = totalSalary
        };
    }
}
