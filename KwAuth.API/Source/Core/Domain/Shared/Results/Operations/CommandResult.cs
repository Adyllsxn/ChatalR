namespace KwAuth.API.Source.Core.Domain.Shared.Results.Operations;
public class CommandResult<TData>
{
    public bool IsSuccess { get; private set; }
    public string? Message { get; private set; }
    public int Code { get; private set; }
    public TData? Value { get; private set; }

    [JsonConstructor]
    private CommandResult(bool isSuccess, TData? value, string? message, int code)
    {
        IsSuccess = isSuccess;
        Message = message;
        Code = code;
        Value = value;
    }

    public static CommandResult<TData> Success(TData value, string? message = MessageResult.Common.Null, int code = StatusCode.OK)
        => new(true, value, message, code);

    public static CommandResult<TData> Failure(TData value, string message, int code = StatusCode.BadRequest)
        => new(false, value, message, code);
    public static CommandResult<TData> Failure(string message, int code = StatusCode.BadRequest)
        => new(false, default, message, code);
}