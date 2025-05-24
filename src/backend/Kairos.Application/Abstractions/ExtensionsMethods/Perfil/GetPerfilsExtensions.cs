namespace Kairos.Application.Abstractions.ExtensionsMethods.Perfil;
public static class GetPerfilsExtensions
{
    public static GetPerfilsResponse MapToGetPerfils (this PerfilEntity entity)
    {
        return new GetPerfilsResponse
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
    public static IEnumerable<GetPerfilsResponse> MapToGetPerfils(this IEnumerable<PerfilEntity> response)
    {
        return response.Select(entity => entity.MapToGetPerfils());
    }

}
