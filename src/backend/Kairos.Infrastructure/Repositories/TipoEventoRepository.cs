namespace Kairos.Infrastructure.Repositories;
public class TipoEventoRepository : ITipoEventoRepository
{
    public Task<Result<TipoEventoEntity>> CreateAsync(TipoEventoEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> DeleteAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<List<TipoEventoEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<TipoEventoEntity?>> GetByIdAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<TipoEventoEntity>?>> SearchAsync(Expression<Func<TipoEventoEntity, bool>> expression, string entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<TipoEventoEntity>> UpdateAsync(TipoEventoEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
