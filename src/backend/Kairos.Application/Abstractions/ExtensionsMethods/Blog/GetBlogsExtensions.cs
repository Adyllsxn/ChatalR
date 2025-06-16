namespace Kairos.Application.Abstractions.ExtensionsMethods.Blog;
public static class GetBlogsExtensions
{
    public static GetBlogsResponse MapToGetBlogs (this BlogEntity entity)
    {
        return new GetBlogsResponse
        {
            Id = entity.Id,
            UsuarioID = entity.UsuarioID,
            Usuario = new UsuarioResponse
            {
                Id = entity.Usuario.Id,
                Nome = entity.Usuario.Nome,
                SobreNome = entity.Usuario.SobreNome,
                Email = entity.Usuario.Email
            },
            Titulo = entity.Titulo,
            Conteudo = entity.Conteudo,
            ImagemCapaUrl = entity.ImagemCapaUrl,
            DataPublicacao = entity.DataPublicacao

        };
    }
    public static IEnumerable<GetBlogsResponse> MapToGetBlogs(this IEnumerable<BlogEntity> response)
    {
        return response.Select(entity => entity.MapToGetBlogs());
    }
}
