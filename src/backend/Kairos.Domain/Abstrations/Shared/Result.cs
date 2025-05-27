namespace Kairos.Domain.Abstrations.Shared;
public class Result<TData>
{
    public int Code { get; set; } = StatusCode.DefaultStatusCode;
    public string? Message { get; set; }
    public TData? Data { get; set; }
    public bool IsOk { get; private set; }
    public string? Error { get; private set; }

    [JsonIgnore]
    public bool IsSuccess => Code is > 200 and <= 299;

    public static Result<TData> Success(TData value) => new Result<TData> { IsOk = true, Data = value, };

    public static Result<TData> Failure(string error) => new Result<TData> { IsOk = false, Error = error };

    [JsonConstructor]
    public Result() => Code = StatusCode.DefaultStatusCode;
    public Result(TData? data, int code = StatusCode.DefaultStatusCode, string? message = null)
    {
        Code = code;
        Message = message;
        Data = data;
    }
}
