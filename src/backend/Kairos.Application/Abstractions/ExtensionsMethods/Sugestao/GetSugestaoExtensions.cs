namespace Kairos.Application.Abstractions.ExtensionsMethods.Sugestao;
public static class GetSugestaoExtensions
{
    public static GetSugestaoResponse MapToGetSugestaos (this SugestaoEntity entity)
    {
        return new GetSugestaoResponse
        {
            Id = entity.Id,
            UsuarioID = entity.UsuarioID,
            EventoID = entity.EventoID,
            Conteudo = entity.Conteudo,
            DataEnvio = entity.DataEnvio
        };
    }
    public static IEnumerable<GetSugestaoResponse> MapToGetSugestaos(this IEnumerable<SugestaoEntity> response)
    {
        return response.Select(entity => entity.MapToGetSugestaos());
    }
}
