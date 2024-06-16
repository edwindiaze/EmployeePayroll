using CSharpFunctionalExtensions;

namespace EmployeePayroll.Domain.ValueObjects;

public class Name
{
    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 20)
        {
            return Result.Failure<Name>($"Name must be between 3 and 20 characters.");
        }

        return Result.Success(new Name(value));
    }
}
