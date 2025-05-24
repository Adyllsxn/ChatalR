namespace Kairos.Application.Abstractions.ExtensionsMethods.TipoEvento;
public static class GetTipoEventoByIdExtensions
{
    public static GetTipoEventoByIdResponse MapToTipoEventoById (this TipoEventoEntity entity)
    {
        return new GetTipoEventoByIdResponse
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
    public static IEnumerable<GetTipoEventoByIdResponse> MapToTipoEventoById(this IEnumerable<TipoEventoEntity> response)
    {
        return response.Select(entity => entity.MapToTipoEventoById());
    }
}
