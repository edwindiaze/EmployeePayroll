using EmployeePayroll.Domain.Entities;

namespace EmployeePayroll.Domain.Interfaces;

public interface ISalaryCalculator
{
    decimal CalculateTotalSalary(Employee employee);
}
