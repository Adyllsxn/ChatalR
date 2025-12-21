namespace KwAuth.API.Source.Core.Domain.Shared.Results.Operations;
public class QueryResult<TData>
{
    public TData? Data { get; set; }
    public string? Message { get; set; }
    public int Code { get; set; } = StatusCode.OK;

    [JsonIgnore]
    public bool IsSuccess => Code is > 200 and <= 299;

    [JsonConstructor]
    public QueryResult(TData? data, string? message = MessageResult.Common.Null, int code = StatusCode.OK)
    {
        Code = code;
        Message = message;
        Data = data;
    }
}