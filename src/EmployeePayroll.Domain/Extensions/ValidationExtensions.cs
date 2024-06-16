using CSharpFunctionalExtensions;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Enums;
using EmployeePayroll.Domain.ValueObjects;

namespace EmployeePayroll.Domain.Extensions;

public static class ValidationExtensions
{
    public static Result ValidateEmployee(this Employee employee)
    {
        var firstNameResult = Name.Create(employee.FirstName);
        if (firstNameResult.IsFailure)
        {
            return Result.Failure(firstNameResult.Error);
        }

        var lastNameResult = Name.Create(employee.LastName);
        if (lastNameResult.IsFailure) {  
            return Result.Failure(lastNameResult.Error);
        }

        if (employee.Age < 10)
        {
            return Result.Failure("Age must be greater than 10.");
        }

        if (employee.WorkedHours < 30 || employee.WorkedHours > 50)
        {
            return Result.Failure("Worked hours must be between 30 and 50.");
        }

        if (employee.SalaryByHours < 13)
        {
            return Result.Failure("Salary by hour must be greater than 13.");
        }

        if (!Enum.IsDefined(typeof(EmployeeTypes), employee.EmployeeType))
        {
            return Result.Failure("Invalid employee type.");
        }

        var emailResult = EmailAddress.Create(employee.Email);
        if (emailResult.IsFailure)
        {
            return Result.Failure(emailResult.Error);
        }

        return Result.Success();
    }
}
