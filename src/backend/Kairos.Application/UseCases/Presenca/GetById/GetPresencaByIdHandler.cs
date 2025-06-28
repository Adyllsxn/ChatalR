namespace Kairos.Application.UseCases.Presenca.GetById;
public class GetPresencaByIdHandler(IPresencaRepository repository)
{
    public async Task<QueryResult<GetPresencaByIdResponse>> GetByIdHandler(GetPresencaByIdCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetPresencaByIdResponse>(
                    data: null, 
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetPresencaById();
            return new QueryResult<GetPresencaByIdResponse>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetPresencaByIdResponse>(
                data: null, 
                message: $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
