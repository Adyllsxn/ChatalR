namespace Kairos.Application.UseCases.Presenca.GetAll;
public class GetPresencaHandler(IPresencaRepository repository)
{
    public async Task<PagedList<List<GetPresencaResponse>?>> GetHandler(GetPresencaCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetAllAsync(command,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new PagedList<List<GetPresencaResponse>?>(
                    data: null,  
                    message: "Nenhum dado encontrado",
                    code: StatusCode.NotFound
                    );
            }
            var result = response.Data.MapToGetPresencas().ToList();
            
            return new PagedList<List<GetPresencaResponse>?>(
                data:result,  
                message: "Dados encontrados",
                code: StatusCode.OK
                );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetPresencaResponse>?>(
                data: null, 
                message: $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
