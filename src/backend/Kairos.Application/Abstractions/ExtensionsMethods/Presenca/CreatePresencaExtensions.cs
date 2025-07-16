namespace Kairos.Application.Abstractions.ExtensionsMethods.Presenca;
public static class CreatePresencaExtensions
{
    public static PresencaEntity MapToPresencaEntity(this CreatePresencaCommand command)
    {
        return new PresencaEntity
        (
            command.UsuarioID,
            command.EventoID,
            command.Confirmado
        );
    }
    
    public static CreatePresencaResponse MapToCreatePresenca (this PresencaEntity entity)
    {
        return new CreatePresencaResponse
        {
            Id = entity.Id,
            UsuarioID = entity.UsuarioID,
            EventoID = entity.UsuarioID,
            Evento = new EventoResponse{
                Id = entity.Evento.Id,
                Titulo = entity.Evento.Titulo
            },
            DataHoraCheckin = entity.DataHoraCheckin
        };
    }
    public static IEnumerable<CreatePresencaResponse> MapToCreatePresenca(this IEnumerable<PresencaEntity> response)
    {
        return response.Select(entity => entity.MapToCreatePresenca());
    }
}
