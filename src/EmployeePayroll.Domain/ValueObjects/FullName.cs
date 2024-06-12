namespace EmployeePayroll.Domain.ValueObjects;

public class FullName
{
    public string Value { get; private set; }

    public FullName(string firstName, string lastName) => Value = $"{firstName} {lastName}";
}
