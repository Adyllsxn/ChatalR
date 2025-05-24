namespace Kairos.Application.Abstractions.ExtensionsMethods.Perfil;
public static class GetPerfilByIdExtensions
{
    public static GetPerfilByIdResponse MapToGetPerfilById (this PerfilEntity entity)
    {
        return new GetPerfilByIdResponse
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
    public static IEnumerable<GetPerfilByIdResponse> MapToGetPerfilById(this IEnumerable<PerfilEntity> response)
    {
        return response.Select(entity => entity.MapToGetPerfilById());
    }
}
