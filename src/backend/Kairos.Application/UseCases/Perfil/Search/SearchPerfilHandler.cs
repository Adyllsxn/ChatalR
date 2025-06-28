namespace Kairos.Application.UseCases.Perfil.Search;
public class SearchPerfilHandler(IPerfilRepository repository)
{
    public async Task<QueryResult<List<SearchPerfilResponse>>> SearchHendler(SearchPerfilCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.SearchAsync(x => x.Nome.Contains(command.Nome),string.Empty,token);
            if (response.Data == null || !response.Data.Any())
            {
                return new QueryResult<List<SearchPerfilResponse>>(
                    data: null, 
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToSearchPerfil().ToList();
            return new QueryResult<List<SearchPerfilResponse>>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch (Exception ex)
        {
            return new QueryResult<List<SearchPerfilResponse>>(
                data: null, 
                message: $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
