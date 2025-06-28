namespace Kairos.Application.UseCases.Usuario.GetFoto;
public class GetUsuarioFotoHandler(IUsuarioRepository repository)
{
    public async Task<QueryResult<GetUsuarioFotoResponse>> GetFotoHandler(GetUsuarioFotoCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetFotoAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetUsuarioFotoResponse>(
                    data: null, 
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetUsuarioFoto();
            return new QueryResult<GetUsuarioFotoResponse>(
                data: result,
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetUsuarioFotoResponse>(
                data: null, 
                message: $"Erro ao manipular a operação (GET FILE). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
