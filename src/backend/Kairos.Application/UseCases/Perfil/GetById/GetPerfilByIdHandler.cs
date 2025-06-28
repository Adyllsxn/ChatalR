namespace Kairos.Application.UseCases.Perfil.GetById;
public class GetPerfilByIdHandler(IPerfilRepository repository)
{
    public async Task<QueryResult<GetPerfilByIdResponse>> GetByIdHandler(GetPerfilByIdCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetPerfilByIdResponse>(
                    data: null,
                    message: response.Message, 
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetPerfilById();
            return new QueryResult<GetPerfilByIdResponse>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetPerfilByIdResponse>(
                data: null, 
                message: $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
