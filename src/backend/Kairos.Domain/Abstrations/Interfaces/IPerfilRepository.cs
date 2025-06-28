namespace Kairos.Domain.Abstrations.Interfaces;
public interface IPerfilRepository
{
    Task<QueryResult<List<PerfilEntity>?>> GetAllAsync (CancellationToken token);
    Task<QueryResult<PerfilEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<QueryResult<List<PerfilEntity>?>> SearchAsync (Expression<Func<PerfilEntity, bool>> expression, string entity, CancellationToken token);
}