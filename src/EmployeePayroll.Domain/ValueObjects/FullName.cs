namespace EmployeePayroll.Domain.ValueObjects;

public class FullName(string firstName, string lastName)
{
    public string Value { get; private set; } = $"{firstName} {lastName}";
}
