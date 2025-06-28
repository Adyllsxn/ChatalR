namespace Kairos.Application.UseCases.Evento.GetById;
public class GetEventoByIdHandler(IEventoRepository repository)
{
    public async Task<QueryResult<GetEventoByIdResponse>> GetByIdHandler(GetEventoByIdCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetEventoByIdResponse>(
                    data: null, 
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetEventoById();
            return new QueryResult<GetEventoByIdResponse>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetEventoByIdResponse>(
                data: null,  
                message: $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}   