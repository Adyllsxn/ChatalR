namespace Kairos.Application.UseCases.Evento.Search;
public class SearchEventoHandler(IEventoRepository repository)
{
    public async Task<QueryResult<List<SearchEventoResponse>>> SearchHendler(SearchEventoCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.SearchAsync(x => x.Titulo.Contains(command.Titulo),string.Empty,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new QueryResult<List<SearchEventoResponse>>(
                    data: null, 
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToSearchEvento().ToList();
            return new QueryResult<List<SearchEventoResponse>>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch (Exception ex)
        {
            return new QueryResult<List<SearchEventoResponse>>(
                data: null, 
                message: $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
