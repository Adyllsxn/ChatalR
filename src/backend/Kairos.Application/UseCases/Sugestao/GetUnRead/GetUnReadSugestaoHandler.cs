namespace Kairos.Application.UseCases.Sugestao.GetUnRead;
public class GetUnReadSugestaoHandler(ISugestaoRepository repository)
{
    public async Task<PagedList<List<GetSugestaoResponse>?>> GetAllUnreadHandler(GetSugestaoCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetAllUnreadAsync(command,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new PagedList<List<GetSugestaoResponse>?>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetSugestaos().ToList();
            
            return new PagedList<List<GetSugestaoResponse>?>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetSugestaoResponse>?>(
                null, 
                500, 
                $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}"
                );
        }
    }
}
