namespace Kairos.Application.UseCases.Evento.GetFile;
public class GetFileEventoHandler(IEventoRepository repository)
{
    public async Task<QueryResult<GetFileEventoResponse>> GetFileHandler(GetFileEventoCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetFileAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetFileEventoResponse>(
                    data: null, 
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetFileEvento();
            return new QueryResult<GetFileEventoResponse>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetFileEventoResponse>(
                data: null, 
                message: $"Erro ao manipular a operação (GET FILE). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}