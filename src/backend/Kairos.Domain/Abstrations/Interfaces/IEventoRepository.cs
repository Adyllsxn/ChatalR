namespace Kairos.Domain.Abstrations.Interfaces;
public interface IEventoRepository
{
    Task<Result<EventoEntity>> CreateAsync (EventoEntity entity, CancellationToken token);
    Task<Result<bool>> DeleteAsync (int entityId, CancellationToken token);
    Task<Result<EventoEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<Result<EventoEntity?>> GetFileAsync (int entityId, CancellationToken token);
    Task<PagedList<List<EventoEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<PagedList<List<EventoEntity>?>> GetEventosAprovadosAsync(PagedRequest request, CancellationToken token);
    Task<PagedList<List<EventoEntity>?>> GetEventosRejeitadosAsync(PagedRequest request, CancellationToken token);
    Task<PagedList<List<EventoEntity>?>> GetEventosPendentesAsync(PagedRequest request, CancellationToken token);
    Task<Result<EventoEntity>> UpdateAsync (EventoEntity entity, CancellationToken token);
    Task<Result<List<EventoEntity>?>> SearchAsync (Expression<Func<EventoEntity, bool>> expression, string entity, CancellationToken token);

}
