namespace Kairos.Application.UseCases.Presenca.Search;
public class SearchPresencaHandler(IPresencaRepository repository)
{
    public async Task<QueryResult<List<SearchPresencaResponse>>> SearchHendler(SearchPresencaCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.SearchAsync(x => x.UsuarioID == command.UsuarioID,string.Empty,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new QueryResult<List<SearchPresencaResponse>>(
                    data: null,
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToSearchPresenca().ToList();
            return new QueryResult<List<SearchPresencaResponse>>(
                data: result,
                message: response.Message,
                code: response.Code
                );
        }
        catch (Exception ex)
        {
            return new QueryResult<List<SearchPresencaResponse>>(
                data: null,
                message: $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
