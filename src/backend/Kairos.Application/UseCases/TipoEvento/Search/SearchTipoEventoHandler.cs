namespace Kairos.Application.UseCases.TipoEvento.Search;
public class SearchTipoEventoHandler(ITipoEventoRepository repository)
{
    public async Task<QueryResult<List<SearchTipoEventoResponse>>> SearchHendler(SearchTipoEventoCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.SearchAsync(x => x.Nome.Contains(command.Nome),string.Empty,token);
            if (response.Data == null || !response.Data.Any())
            {
                return new QueryResult<List<SearchTipoEventoResponse>>(
                    data: null, 
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToSearchTipoEvento().ToList();
            return new QueryResult<List<SearchTipoEventoResponse>>(
                data: result,
                message: response.Message,
                code: response.Code
                );
        }
        catch (Exception ex)
        {
            return new QueryResult<List<SearchTipoEventoResponse>>(
                data: null, 
                message: $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}