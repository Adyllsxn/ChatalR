namespace Kairos.Application.Abstractions.ExtensionsMethods.Usuario;
public static class SearchUsuarioExtensions
{
    public static SearchUsuarioResponse MapToSearchUsuario(this UsuarioEntity entity)
    {
        return new SearchUsuarioResponse
        {
            Id = entity.Id,
            Nome = entity.Nome,
            SobreNome = entity.SobreNome,
            Email = entity.Email,
            FotoUrl = entity.FotoUrl,
            PerfilID = entity.PerfilID,
            Perfil = new PerfilResponse
            {
                Id = entity.Perfil.Id,
                Nome = entity.Perfil.Nome
            },
            DataCadastro = entity.DataCadastro,
            Telefone = entity.Telefone,
            BI = entity.BI
        };
    }
    public static IEnumerable<SearchUsuarioResponse> MapToSearchUsuario(this IEnumerable<UsuarioEntity> response)
    {
        return response.Select(entity => entity.MapToSearchUsuario());
    }
}