namespace Kairos.Application.Abstractions.ExtensionsMethods.TipoEvento;
public static class UpdateTipoEventoExtensions 
{
    public static TipoEventoEntity MapToTipoEventoEntity(this UpdateTipoEventoCommand command)
        => new(command.Id, command.Nome);
    
    public static UpdateTipoEventoResponse MapToUpdateTipoEvento (this TipoEventoEntity entity)
    {
        return new UpdateTipoEventoResponse
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
    public static IEnumerable<UpdateTipoEventoResponse> MapToUpdateTipoEvento(this IEnumerable<TipoEventoEntity> response)
    {
        return response.Select(entity => entity.MapToUpdateTipoEvento());
    }
}