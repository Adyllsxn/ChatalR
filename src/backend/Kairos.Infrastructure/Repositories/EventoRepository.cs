namespace Kairos.Infrastructure.Repositories;
public class EventoRepository : IEventoRepository
{
    public Task<Result<EventoEntity>> CreateAsync(EventoEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> DeleteAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<List<EventoEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<EventoEntity?>> GetByIdAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<EventoEntity?>> GetFileAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<EventoEntity>?>> SearchAsync(Expression<Func<EventoEntity, bool>> expression, string entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<EventoEntity>> UpdateAsync(EventoEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
