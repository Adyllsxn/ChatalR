namespace Kairos.Application.Services;
public class TipoEventoService(GetTipoEventosHandler get) : ITipoEventoService
{
    public async Task<PagedList<List<GetTipoEventosResponse>?>> GetHandler(GetTipoEventosCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }
}
