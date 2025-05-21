namespace Kairos.Domain.Abstrations.Interfaces;
public interface IPerfilRepository
{
    Task<Result<PerfilEntity>> CreateAsync (PerfilEntity entity, CancellationToken token);
    Task<Result<bool>> DeleteAsync (int entityId, CancellationToken token);
    Task<Result<PerfilEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<Result<List<PerfilEntity>?>> GetAllAsync (CancellationToken token);
    Task<Result<PerfilEntity>> UpdateAsync (PerfilEntity entity, CancellationToken token);
    Task<Result<List<PerfilEntity>?>> SearchAsync (Expression<Func<PerfilEntity, bool>> expression, string entity, CancellationToken token);
}