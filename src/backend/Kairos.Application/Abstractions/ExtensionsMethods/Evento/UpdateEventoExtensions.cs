namespace Kairos.Application.Abstractions.ExtensionsMethods.Evento;
public static class UpdateEventoExtensions
{
    public static EventoEntity MapToEventoEntity(this UpdateEventoCommand command)
    {
        return new EventoEntity
        (
            command.Id,
            command.Titulo,
            command.Descricao,
            command.DataHoraInicio,
            command.DataHoraFim,
            command.Local,
            command.TipoEventoID,
            command.UsuarioID,
            command.ImagemUrl
        );
    }
    
    public static UpdateEventoResponse MapToUpdateEvento (this EventoEntity entity)
    {
        return new UpdateEventoResponse
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
    public static IEnumerable<UpdateEventoResponse> MapToUpdateEvento(this IEnumerable<EventoEntity> response)
    {
        return response.Select(entity => entity.MapToUpdateEvento());
    }
}
