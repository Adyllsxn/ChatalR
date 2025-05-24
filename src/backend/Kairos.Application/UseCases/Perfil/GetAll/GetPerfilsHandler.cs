namespace Kairos.Application.UseCases.Perfil.GetAll;
public class GetPerfilsHandler(IPerfilRepository repository)
{
    public async Task<Result<List<GetPerfilsResponse>>> GetHandler(CancellationToken token)
    {
        try
        {
            var response = await repository.GetAllAsync(token);

            if (response.Data == null || !response.Data.Any())
            {
                return new Result<List<GetPerfilsResponse>>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetPerfils().ToList();
            
            return new Result<List<GetPerfilsResponse>>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new Result<List<GetPerfilsResponse>>(
                null, 
                500, 
                $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}"
                );
        }
    }
}
