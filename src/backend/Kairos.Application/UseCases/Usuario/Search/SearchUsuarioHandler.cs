namespace Kairos.Application.UseCases.Usuario.Search;
public class SearchUsuarioHandler(IUsuarioRepository repository)
{
    public async Task<QueryResult<List<SearchUsuarioResponse>>> SearchHendler(SearchUsuarioCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.SearchAsync(x => x.Nome.Contains(command.Nome),string.Empty,token);
            if (response.Data == null || !response.Data.Any())
            {
                return new QueryResult<List<SearchUsuarioResponse>>(
                    data: null, 
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToSearchUsuario().ToList();
            return new QueryResult<List<SearchUsuarioResponse>>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch (Exception ex)
        {
            return new QueryResult<List<SearchUsuarioResponse>>(
                data: null, 
                message: $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}