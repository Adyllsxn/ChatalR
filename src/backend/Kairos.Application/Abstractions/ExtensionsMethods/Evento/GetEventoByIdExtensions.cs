namespace Kairos.Application.Abstractions.ExtensionsMethods.Evento;
public static class GetEventoByIdExtensions
{
    public static GetEventoByIdResponse MapToGetEventoById (this EventoEntity entity)
    {
        return new GetEventoByIdResponse
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
            ImagemUrl = entity.ImagemUrl
        };
    }
    public static IEnumerable<GetEventoByIdResponse> MapToGetEventoById(this IEnumerable<EventoEntity> response)
    {
        return response.Select(entity => entity.MapToGetEventoById());
    }
}
