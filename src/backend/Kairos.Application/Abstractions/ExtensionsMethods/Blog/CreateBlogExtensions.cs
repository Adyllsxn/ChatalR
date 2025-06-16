namespace Kairos.Application.Abstractions.ExtensionsMethods.Blog;
public static class CreateBlogExtensions
{
    public static BlogEntity MapToBlogEntity(this CreateBlogCommand command)
    {

        return new BlogEntity
        (
            command.UsuarioID,
            command.Titulo,
            command.Conteudo,
            command.ImagemCapaUrl,
            command.DataPublicacao
        );
    }
    
    public static CreateBlogResponse MapToCreateBlog (this BlogEntity entity)
    {
        return new CreateBlogResponse
        {
            Id = entity.Id,
            UsuarioID = entity.UsuarioID,
            Titulo = entity.Titulo,
            Conteudo = entity.Conteudo,
            ImagemCapaUrl = entity.ImagemCapaUrl,
            DataPublicacao = entity.DataPublicacao
        };
    }
    public static IEnumerable<CreateBlogResponse> MapToCreateBlog(this IEnumerable<BlogEntity> response)
    {
        return response.Select(entity => entity.MapToCreateBlog());
    }
}
