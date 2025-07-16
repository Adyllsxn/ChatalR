namespace Kairos.Application.Abstractions.ExtensionsMethods.Presenca;
public static class GetPresencasExtensions
{
    public static GetPresencaResponse MapToGetPresencas (this PresencaEntity entity)
    {
        return new GetPresencaResponse
        {
            Id = entity.Id,
            UsuarioID = entity.UsuarioID,
            EventoID = entity.EventoID,
            Evento = new EventoResponse{
                Id = entity.Evento.Id,
                Titulo = entity.Evento.Titulo
            },
            DataHoraCheckin = entity.DataHoraCheckin
        };
    }
    public static IEnumerable<GetPresencaResponse> MapToGetPresencas(this IEnumerable<PresencaEntity> response)
    {
        return response.Select(entity => entity.MapToGetPresencas());
    }
}
