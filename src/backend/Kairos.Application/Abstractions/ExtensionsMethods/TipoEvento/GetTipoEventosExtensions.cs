namespace Kairos.Application.Abstractions.ExtensionsMethods.TipoEvento;
public static class GetTipoEventosExtensions
{
    public static GetTipoEventosResponse MapToGetTipoEventos (this TipoEventoEntity entity)
    {
        return new GetTipoEventosResponse
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
    public static IEnumerable<GetTipoEventosResponse> MapToGetTipoEventos(this IEnumerable<TipoEventoEntity> response)
    {
        return response.Select(entity => entity.MapToGetTipoEventos());
    }
}
