namespace Kairos.Application.Abstractions.ExtensionsMethods.Sugestao;
public static class GetSugestaoByIdExtensions
{
    public static GetSugestaoByIdResponse MapToGetSugestaoById (this SugestaoEntity entity)
    {
        return new GetSugestaoByIdResponse
        {
            Id = entity.Id,
            UsuarioID = entity.UsuarioID,
            EventoID = entity.EventoID,
            Conteudo = entity.Conteudo,
            DataEnvio = entity.DataEnvio
        };
    }
    public static IEnumerable<GetSugestaoByIdResponse> MapToGetSugestaoById(this IEnumerable<SugestaoEntity> response)
    {
        return response.Select(entity => entity.MapToGetSugestaoById());
    }
}
