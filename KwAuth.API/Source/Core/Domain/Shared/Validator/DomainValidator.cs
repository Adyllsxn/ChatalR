namespace KwAuth.API.Source.Core.Domain.Shared.Validator;
public static class DomainValidator
{
    public static void When(bool condition, string message)
    {
        if (condition)
            throw new DomainException(message);
    }
    
    public static void NotEmpty(string value, string fieldName)
    {
        When(string.IsNullOrWhiteSpace(value), $"{fieldName} cannot be empty");
    }
}