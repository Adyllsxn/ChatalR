namespace Kairos.Application.Abstractions.ExtensionsMethods.Evento;
public static class SearchEventoExtensions
{
    public static SearchEventoResponse MapToSearchEvento(this EventoEntity entity)
    {
        return new SearchEventoResponse
        {
            Id = entity.Id,
            Titulo = entity.Titulo,
            Descricao = entity.Descricao,
            DataHoraInicio = entity.DataHoraInicio,
            DataHoraFim = entity.DataHoraFim,
            Local = entity.Local,
            TipoEventoID = entity.TipoEventoID,
            UsuarioID = entity.UsuarioID,
            ImagemUrl = entity.ImagemUrl
        };
    }
    public static IEnumerable<SearchEventoResponse> MapToSearchEvento(this IEnumerable<EventoEntity> response)
    {
        return response.Select(entity => entity.MapToSearchEvento());
    }
}
