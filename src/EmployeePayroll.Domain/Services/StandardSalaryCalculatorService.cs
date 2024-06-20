using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Enums;
using EmployeePayroll.Domain.Interfaces;

namespace EmployeePayroll.Domain.Services;

public class StandardSalaryCalculatorService : ISalaryCalculator
{
    public decimal CalculateTotalSalary(Employee employee)
    {
        var baseSalary = employee.GetBaseSalary();
        var multiplier = employee.EmployeeType switch
        {
            EmployeeTypes.Associate => 1.0m,
            EmployeeTypes.Technical => 1.12m,
            EmployeeTypes.Senior => 1.25m,
            EmployeeTypes.Lead => 1.5m,
            _ => throw new ArgumentOutOfRangeException()
        };
        return baseSalary * multiplier;
    }
}
