namespace Kairos.Application.UseCases.Usuario.GetById;
public class GetUsuarioByIdHandler(IUsuarioRepository repository)
{
    public async Task<QueryResult<GetUsuarioByIdResponse>> GetByIdHandler(GetUsuarioByIdCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetUsuarioByIdResponse>(
                    data: null, 
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetUsuarioById();
            return new QueryResult<GetUsuarioByIdResponse>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetUsuarioByIdResponse>(
                data: null,
                message: $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}