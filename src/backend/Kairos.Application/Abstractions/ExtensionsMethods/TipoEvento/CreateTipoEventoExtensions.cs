namespace Kairos.Application.Abstractions.ExtensionsMethods.TipoEvento;
public static class CreateTipoEventoExtensions
{
    public static TipoEventoEntity MapToTipoEventoEntity(this CreateTipoEventoCommand command)
    {
        return new TipoEventoEntity
        (
            command.Nome
        );
    }
    
    public static CreateTipoEventoResponse MapToCreateTipoEvento (this TipoEventoEntity entity)
    {
        return new CreateTipoEventoResponse
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
    public static IEnumerable<CreateTipoEventoResponse> MapToCreateTipoEvento(this IEnumerable<TipoEventoEntity> response)
    {
        return response.Select(entity => entity.MapToCreateTipoEvento());
    }
}
