namespace Kairos.Application.UseCases.Usuario.GetAll;
public class GetUsuariosHandler(IUsuarioRepository repository)
{
    public async Task<PagedList<List<GetUsuariosResponse>?>> GetHandler(GetUsuariosCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetAllAsync(command,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new PagedList<List<GetUsuariosResponse>?>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetUsuarios().ToList();
            
            return new PagedList<List<GetUsuariosResponse>?>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetUsuariosResponse>?>(
                null, 
                500, 
                $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}"
                );
        }
    }
}