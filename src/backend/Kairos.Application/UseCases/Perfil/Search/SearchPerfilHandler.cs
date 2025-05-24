namespace Kairos.Application.UseCases.Perfil.Search;
public class SearchPerfilHandler(IPerfilRepository repository)
{
    public async Task<Result<List<SearchPerfilResponse>>> SearchHendler(SearchPerfilCommand command, CancellationToken token)
    {
        try
        {
            if(command.Nome == null)
            {
                return new Result<List<SearchPerfilResponse>>(
                    null, 
                    400, 
                    "Parâmetro não deve estar vazio."
                    );
            }
            var response = await repository.SearchAsync(x => x.Nome.Contains(command.Nome),string.Empty,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new Result<List<SearchPerfilResponse>>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToSearchPerfil().ToList();
            
            return new Result<List<SearchPerfilResponse>>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new Result<List<SearchPerfilResponse>>(
                null, 
                500, 
                $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}"
                );
        }
    }
}
