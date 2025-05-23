namespace Kairos.Application.Abstractions.Interfaces;
public interface ITipoEventoService
{
    Task<PagedList<List<GetTipoEventosResponse>?>> GetHandler(GetTipoEventosCommand command, CancellationToken token);
}
