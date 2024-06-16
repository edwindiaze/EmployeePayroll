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
            EmployeeTypes.Technical => 1.1m,
            EmployeeTypes.Senior => 1.2m,
            EmployeeTypes.Lead => 1.3m,
            _ => throw new ArgumentOutOfRangeException()
        };
        return baseSalary * multiplier;
    }
}
