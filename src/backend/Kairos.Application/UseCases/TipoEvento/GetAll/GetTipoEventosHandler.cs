namespace Kairos.Application.UseCases.TipoEvento.GetAll;
public class GetTipoEventosHandler(ITipoEventoRepository repository)
{
    public async Task<PagedList<List<GetTipoEventosResponse>?>> GetHandler(GetTipoEventosCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetAllAsync(command,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new PagedList<List<GetTipoEventosResponse>?>(
                    new List<GetTipoEventosResponse>(), 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetTipoEventos().ToList();
            
            return new PagedList<List<GetTipoEventosResponse>?>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetTipoEventosResponse>?>(
                null, 
                500, 
                $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}"
                );
        }
    }
}
