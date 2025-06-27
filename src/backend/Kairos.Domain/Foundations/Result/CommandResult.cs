namespace Kairos.Domain.Foundations.Result;
public class CommandResult<TData>
{
    public bool IsSuccess { get; private set; }
    public string? Message { get; private set; }
    public int Code { get; private set; }
    protected TData? Value { get; private set; }

    private CommandResult(bool isSuccess, TData? value, string? message, int code)
    {
        IsSuccess = isSuccess;
        Message = message;
        Code = code;
        Value = value;
    }

    public static CommandResult<TData> Success(TData value, string? message = null, int code = 200)
        => new(true, value, message, code);

    public static CommandResult<TData> Failure(TData value, string message, int code = 400)
        => new(false, value, message, code);
}
