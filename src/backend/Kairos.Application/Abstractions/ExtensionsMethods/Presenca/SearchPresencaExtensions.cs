namespace Kairos.Application.Abstractions.ExtensionsMethods.Presenca;
public static class SearchPresencaExtensions
{
    public static SearchPresencaResponse MapToSearchPresenca(this PresencaEntity entity)
    {
        return new SearchPresencaResponse
        {
            Id = entity.Id,
            UsuarioID = entity.UsuarioID,
            EventoID = entity.EventoID,
            Evento = new EventoResponse{
                Id = entity.Evento.Id,
                Titulo = entity.Evento.Titulo,
                Descricao = entity.Evento.Descricao,
                DataHoraInicio = entity.Evento.DataHoraInicio,
                DataHoraFim = entity.Evento.DataHoraFim,
                Local = entity.Evento.Local,
                ImagemUrl = entity.Evento.ImagemUrl
            },
            DataHoraCheckin = entity.DataHoraCheckin
        };
    }
    public static IEnumerable<SearchPresencaResponse> MapToSearchPresenca(this IEnumerable<PresencaEntity> response)
    {
        return response.Select(entity => entity.MapToSearchPresenca());
    }
}
