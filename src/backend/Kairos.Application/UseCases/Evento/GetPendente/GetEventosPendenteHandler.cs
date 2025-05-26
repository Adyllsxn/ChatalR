namespace Kairos.Application.UseCases.Evento.GetPendente;
public class GetEventosPendenteHandler(IEventoRepository repository)
{
    public async Task<PagedList<List<GetEventosResponse>?>> GePendentetHandler(GetEventosCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetEventosPendentesAsync(command,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new PagedList<List<GetEventosResponse>?>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetEventos().ToList();
            
            return new PagedList<List<GetEventosResponse>?>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetEventosResponse>?>(
                null, 
                500, 
                $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}"
                );
        }
    }
}
