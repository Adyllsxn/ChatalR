namespace Kairos.Domain.Abstrations.Interfaces;
public interface ITipoEventoRepository
{
    Task<QueryResult<TipoEventoEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<PagedList<List<TipoEventoEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<QueryResult<List<TipoEventoEntity>?>> SearchAsync (Expression<Func<TipoEventoEntity, bool>> expression, string entity, CancellationToken token);
    Task<CommandResult<bool>> CreateAsync (TipoEventoEntity entity, CancellationToken token);
    Task<QueryResult<TipoEventoEntity>> UpdateAsync (TipoEventoEntity entity, CancellationToken token);
    Task<QueryResult<bool>> DeleteAsync (int entityId, CancellationToken token);
}
