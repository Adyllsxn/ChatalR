namespace Kairos.Domain.Abstrations.Interfaces;
public interface ISugestaoRepository
{
    Task<Result<SugestaoEntity>> CreateAsync (SugestaoEntity entity, CancellationToken token);
    Task<Result<bool>> DeleteAsync (int entityId, CancellationToken token);
    Task<Result<SugestaoEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<PagedList<List<SugestaoEntity>?>> GetAllUnreadAsync(PagedRequest request, CancellationToken token);
    Task<PagedList<List<SugestaoEntity>?>> GetAllReadAsync(PagedRequest request, CancellationToken token);
    Task<PagedList<List<SugestaoEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<Result<SugestaoEntity>> UpdateAsync (SugestaoEntity entity, CancellationToken token);
    Task<Result<bool>> MarkAsReadAsync(int id, CancellationToken token);
}
