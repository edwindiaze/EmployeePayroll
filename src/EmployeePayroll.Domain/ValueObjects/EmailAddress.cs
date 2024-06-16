using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace EmployeePayroll.Domain.ValueObjects;

public class EmailAddress
{
    public string Value { get; }

    private EmailAddress(string value)
    {
        Value = value;
    }

    public static Result<EmailAddress> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<EmailAddress>("Email address cannot be null or empty.");
        }

        string emailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
        Regex regex = new(emailPattern);

        if (!regex.IsMatch(value))
        {
            return Result.Failure<EmailAddress>("Email address is not valid.");
        }

        return Result.Success(new EmailAddress(value));
    }
}
