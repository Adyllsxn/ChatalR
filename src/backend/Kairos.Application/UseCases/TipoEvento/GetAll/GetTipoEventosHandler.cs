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
                    data: new List<GetTipoEventosResponse>(), 
                    message:"Nenhum dado encontrado",
                    code: StatusCode.NotFound
                    );
            }
            var result = response.Data.MapToGetTipoEventos().ToList();
            
            return new PagedList<List<GetTipoEventosResponse>?>(
                data: result, 
                message: "Dados encontrados",
                code: StatusCode.OK
                );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetTipoEventosResponse>?>(
                data: null,
                message: $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
