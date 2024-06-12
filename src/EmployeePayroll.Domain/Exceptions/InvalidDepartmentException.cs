namespace EmployeePayroll.Domain.Exceptions;

public class InvalidDepartmentException(string message) : DomainException(message)
{
}