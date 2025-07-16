namespace Kairos.Application.Abstractions.ExtensionsMethods.Presenca;
public static class GetPresencaByIdExtensions
{
    public static GetPresencaByIdResponse MapToGetPresencaById (this PresencaEntity entity)
    {
        return new GetPresencaByIdResponse
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
    public static IEnumerable<GetPresencaByIdResponse> MapToGetPresencaById(this IEnumerable<PresencaEntity> response)
    {
        return response.Select(entity => entity.MapToGetPresencaById());
    }
}
