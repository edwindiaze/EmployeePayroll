namespace EmployeePayroll.Domain.Exceptions;

public class InvalidEmployeeException(string message) : DomainException(message)
{
}