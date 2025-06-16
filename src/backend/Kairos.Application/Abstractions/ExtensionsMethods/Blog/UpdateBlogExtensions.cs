namespace Kairos.Application.Abstractions.ExtensionsMethods.Blog;
public static class UpdateBlogExtensions
{
    public static BlogEntity MapToBlogEntity(this UpdateBlogCommand command)
    {
        return new BlogEntity
        (
            command.Id,
            command.UsuarioID,
            command.Titulo,
            command.Conteudo,
            command.ImagemCapaUrl,
            command.DataPublicacao
        );
    }
    
    public static UpdateBlogResponse MapToUpdateBlog (this BlogEntity entity)
    {
        return new UpdateBlogResponse
        {
            Id = entity.Id,
            UsuarioID = entity.UsuarioID,
            Titulo = entity.Titulo,
            Conteudo = entity.Conteudo,
            ImagemCapaUrl = entity.ImagemCapaUrl,
            DataPublicacao = entity.DataPublicacao
        };
    }
    public static IEnumerable<UpdateBlogResponse> MapToUpdateBlog(this IEnumerable<BlogEntity> response)
    {
        return response.Select(entity => entity.MapToUpdateBlog());
    }
}
