namespace Kairos.Application.Abstractions.ExtensionsMethods.Evento;
public static class UpdateEventoStatusExtensions
{
    public static UpdateEventoStatusResponse MapToUpdateStatusResponse(this EventoEntity entity)
    {
        return new UpdateEventoStatusResponse
        {
            Id = entity.Id,
            StatusAprovacao = entity.StatusAprovacao
        };
    }
}

