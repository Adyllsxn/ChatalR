namespace Kairos.Application.Abstractions.ExtensionsMethods.Blog;
public static class GetBlogByIdExtensions
{
    public static GetBlogByIdResponse MapToGetBlogById (this BlogEntity entity)
    {
        return new GetBlogByIdResponse
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
    public static IEnumerable<GetBlogByIdResponse> MapToGetBlogById(this IEnumerable<BlogEntity> response)
    {
        return response.Select(entity => entity.MapToGetBlogById());
    }
}
