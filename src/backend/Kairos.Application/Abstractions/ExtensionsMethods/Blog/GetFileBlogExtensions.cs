namespace Kairos.Application.Abstractions.ExtensionsMethods.Blog;
public static class GetFileBlogExtensions
{
    public static GetFileBlogResponse MapToGetFileBlog (this BlogEntity entity)
    {
        return new GetFileBlogResponse
        {
            ImagemCapaUrl = entity.ImagemCapaUrl
        };
    }
    public static IEnumerable<GetFileBlogResponse> MapToGetFileBlog(this IEnumerable<BlogEntity> response)
    {
        return response.Select(entity => entity.MapToGetFileBlog());
    }
}
