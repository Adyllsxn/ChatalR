namespace Kairos.Domain.Abstrations.Interfaces;
public interface IPresencaRepository
{
    Task<Result<PresencaEntity>> CreateAsync (PresencaEntity entity, CancellationToken token);
    Task<Result<bool>> DeleteAsync (int entityId, CancellationToken token);
    Task<Result<PresencaEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<PagedList<List<PresencaEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<Result<PresencaEntity>> UpdateAsync (PresencaEntity entity, CancellationToken token);
}
