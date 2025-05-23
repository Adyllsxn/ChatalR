namespace Kairos.Application.Abstractions.ExtensionsMethods.TipoEvento;
public static class SearchTipoEventoExtensions
{
    public static SearchTipoEventoResponse MapToSearchTipoEvento (this TipoEventoEntity entity)
    {
        return new SearchTipoEventoResponse
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
    public static IEnumerable<SearchTipoEventoResponse> MapToSearchTipoEvento(this IEnumerable<TipoEventoEntity> response)
    {
        return response.Select(entity => entity.MapToSearchTipoEvento());
    }
}
