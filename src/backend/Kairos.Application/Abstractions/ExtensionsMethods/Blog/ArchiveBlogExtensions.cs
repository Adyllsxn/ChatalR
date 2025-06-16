namespace Kairos.Application.Abstractions.ExtensionsMethods.Blog;
public static class ArchiveBlogExtensions
{
    public static ArchiveBlogResponse MapToArchivePostagem(this BlogEntity entity)
    {
        return new ArchiveBlogResponse
        {
            Id = entity.Id,
            StatusPostagem = entity.Status
        };
    }
}
