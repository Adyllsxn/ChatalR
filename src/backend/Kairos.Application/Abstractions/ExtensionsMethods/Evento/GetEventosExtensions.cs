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
            TipoEvento = new TipoEventoResponse
            {
                Id = entity.TipoEvento.Id,
                Nome = entity.TipoEvento.Nome
            },
            Usuario = new UsuarioResponse
            {
                Id = entity.Usuario.Id,
                Nome = entity.Usuario.Nome,
                SobreNome = entity.Usuario.SobreNome,
                Email = entity.Usuario.Email
            },
            UsuarioID = entity.UsuarioID,
            StatusAprovacao = entity.StatusAprovacao,
            ImagemUrl = entity.ImagemUrl
        };
    }
    public static IEnumerable<GetEventosResponse> MapToGetEventos(this IEnumerable<EventoEntity> response)
    {
        return response.Select(entity => entity.MapToGetEventos());
    }
}
