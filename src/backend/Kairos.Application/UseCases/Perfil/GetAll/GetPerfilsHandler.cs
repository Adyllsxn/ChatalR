namespace Kairos.Application.UseCases.Perfil.GetAll;
public class GetPerfilsHandler(IPerfilRepository repository)
{
    public async Task<QueryResult<List<GetPerfilsResponse>>> GetHandler(CancellationToken token)
    {
        try
        {
            var response = await repository.GetAllAsync(token);
            if (response.Data == null || !response.Data.Any())
            {
                return new QueryResult<List<GetPerfilsResponse>>(
                    data: null, 
                    response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetPerfils().ToList();
            return new QueryResult<List<GetPerfilsResponse>>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch (Exception ex)
        {
            return new QueryResult<List<GetPerfilsResponse>>(
                data: null, 
                message: $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
