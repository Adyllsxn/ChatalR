namespace Kairos.Application.Abstractions.ExtensionsMethods.Sugestao;
public static class CreateSugestaoExtensions
{
    public static SugestaoEntity MapToSugestaoEntity(this CreateSugestaoCommand command)
    {

        return new SugestaoEntity
        (
            command.UsuarioID,
            command.EventoID,
            command.Conteudo,
            command.DataEnvio
        );
    }
    
    public static CreateSugestaoResponse MapToCreateSugestao (this SugestaoEntity entity)
    {
        return new CreateSugestaoResponse
        {
            Id = entity.Id,
            UsuarioID = entity.UsuarioID,
            EventoID = entity.EventoID,
            Conteudo = entity.Conteudo,
            DataEnvio = entity.DataEnvio
        };
    }
    public static IEnumerable<CreateSugestaoResponse> MapToCreateSugestao(this IEnumerable<SugestaoEntity> response)
    {
        return response.Select(entity => entity.MapToCreateSugestao());
    }
}
