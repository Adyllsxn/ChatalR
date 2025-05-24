namespace Kairos.Application.UseCases.Usuario.Search;
public class SearchUsuarioHandler(IUsuarioRepository repository)
{
    public async Task<Result<List<SearchUsuarioResponse>>> SearchHendler(SearchUsuarioCommand command, CancellationToken token)
    {
        try
        {
            if(command.Nome == null)
            {
                return new Result<List<SearchUsuarioResponse>>(
                    null, 
                    400, 
                    "Parâmetro não deve estar vazio."
                    );
            }
            var response = await repository.SearchAsync(x => x.Nome.Contains(command.Nome),string.Empty,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new Result<List<SearchUsuarioResponse>>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToSearchUsuario().ToList();
            
            return new Result<List<SearchUsuarioResponse>>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new Result<List<SearchUsuarioResponse>>(
                null, 
                500, 
                $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}"
                );
        }
    }
}