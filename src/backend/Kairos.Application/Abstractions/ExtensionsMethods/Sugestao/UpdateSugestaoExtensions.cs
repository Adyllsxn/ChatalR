namespace Kairos.Application.Abstractions.ExtensionsMethods.Sugestao;
public static class UpdateSugestaoExtensions
{
    public static SugestaoEntity MapToSugestaoEntity(this UpdateSugestaoCommand command)
    {
        return new SugestaoEntity
        (
            command.Id,
            command.UsuarioID,
            command.EventoID,
            command.Conteudo,
            command.DataEnvio
        );
    }
    
    public static UpdateSugestaoResponse MapToUpdateSugestao (this SugestaoEntity entity)
    {
        return new UpdateSugestaoResponse
        {
            Id = entity.Id,
            UsuarioID = entity.UsuarioID,
            EventoID = entity.EventoID,
            Conteudo = entity.Conteudo,
            DataEnvio = entity.DataEnvio
        };
    }
    public static IEnumerable<UpdateSugestaoResponse> MapToUpdateSugestao(this IEnumerable<SugestaoEntity> response)
    {
        return response.Select(entity => entity.MapToUpdateSugestao());
    }
}
