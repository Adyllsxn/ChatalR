namespace Kairos.Application.UseCases.TipoEvento.Search;
public class SearchTipoEventoHandler(ITipoEventoRepository repository)
{
    public async Task<Result<List<SearchTipoEventoResponse>>> SearchHendler(SearchTipoEventoCommand command, CancellationToken token)
    {
        try
        {
            if(command.Nome == null)
            {
                return new Result<List<SearchTipoEventoResponse>>(
                    null, 
                    400, 
                    "Parâmetro não deve estar vazio."
                    );
            }
            var response = await repository.SearchAsync(x => x.Nome.Contains(command.Nome),string.Empty,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new Result<List<SearchTipoEventoResponse>>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToSearchTipoEvento().ToList();
            
            return new Result<List<SearchTipoEventoResponse>>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new Result<List<SearchTipoEventoResponse>>(
                null, 
                500, 
                $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}"
                );
        }
    }
}