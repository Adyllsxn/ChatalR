namespace Kairos.Domain.Abstrations.Interfaces;
public interface ITipoEventoRepository
{
    Task<Result<TipoEventoEntity>> CreateAsync (TipoEventoEntity entity, CancellationToken token);
    Task<Result<bool>> DeleteAsync (int entityId, CancellationToken token);
    Task<Result<TipoEventoEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<PagedList<List<TipoEventoEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<Result<TipoEventoEntity>> UpdateAsync (TipoEventoEntity entity, CancellationToken token);
    Task<Result<List<TipoEventoEntity>?>> SearchAsync (Expression<Func<TipoEventoEntity, bool>> expression, string entity, CancellationToken token);
}
