namespace KwAuth.API.Source.Core.Domain.Shared.Paginations;
public class PagedList<TData> : QueryResult<TData>
{
    public int CurrentPage { get; set; }
    public int TotalPage => (int)Math.Ceiling(TotalCount / (double) PageSize);
    public int PageSize { get; set; } = PagedConfig.DefaultPageSize;
    public int TotalCount { get; set; }

    [JsonConstructor]
    public PagedList(TData? data, int totalCount, int currentPage = 1, int pageSize = PagedConfig.DefaultPageSize) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
    public PagedList(TData? data, int code, string? message = null) : base(data, message,code){}
}