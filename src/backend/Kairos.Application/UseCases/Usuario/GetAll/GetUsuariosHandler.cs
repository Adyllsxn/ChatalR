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
                    data: null, 
                    message: "Nenhum dado encontrado",
                    code: StatusCode.NotFound
                    );
            }
            var result = response.Data.MapToGetUsuarios().ToList();
            
            return new PagedList<List<GetUsuariosResponse>?>(
                data: result, 
                message: "Dados encontrados",
                code: StatusCode.OK
                );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetUsuariosResponse>?>(
                data:null, 
                message: $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}