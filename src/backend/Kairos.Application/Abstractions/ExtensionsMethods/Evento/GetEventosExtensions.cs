namespace Kairos.Application.Abstractions.ExtensionsMethods.Evento;
public static class GetEventosExtensions
{
    public static GetEventosResponse MapToGetEventos (this EventoEntity entity)
    {
        return new GetEventosResponse
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
    public static IEnumerable<GetEventosResponse> MapToGetEventos(this IEnumerable<EventoEntity> response)
    {
        return response.Select(entity => entity.MapToGetEventos());
    }
}
