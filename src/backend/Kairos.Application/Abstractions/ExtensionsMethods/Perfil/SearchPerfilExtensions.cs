namespace Kairos.Application.Abstractions.ExtensionsMethods.Perfil;
public static class SearchPerfilExtensions
{
    public static SearchPerfilResponse MapToSearchPerfil (this PerfilEntity entity)
    {
        return new SearchPerfilResponse
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
    public static IEnumerable<SearchPerfilResponse> MapToSearchPerfil(this IEnumerable<PerfilEntity> response)
    {
        return response.Select(entity => entity.MapToSearchPerfil());
    }
}
