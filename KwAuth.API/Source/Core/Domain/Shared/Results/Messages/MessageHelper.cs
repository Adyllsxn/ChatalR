namespace KwAuth.API.Source.Core.Domain.Shared.Results.Messages;
public static class MessageHelper
{
    public static string Format(string template, string entityName)
    {
        return string.Format(template, entityName.ToLower());
    }
}
