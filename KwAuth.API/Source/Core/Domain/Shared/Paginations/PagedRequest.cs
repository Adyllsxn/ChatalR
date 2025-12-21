namespace KwAuth.API.Source.Core.Domain.Shared.Paginations;
public class PagedRequest
{
    public int PageNumber { get; set; } = PagedConfig.DefaultPageNumber;
    public int PageSize { get; set; } = PagedConfig.DefaultPageSize;
    public int Skip => (PageNumber - 1) * PageSize;
    public int Take => PageSize;
    
    public void Validate()
    {
        PageNumber = Math.Max(1, PageNumber);
        PageSize = Math.Clamp(PageSize, 1, PagedConfig.MaxPageSize);
    }
}