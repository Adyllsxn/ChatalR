namespace Kairos.Domain.Abstrations.Interfaces;
public interface IBlogRepository
{
    Task<Result<BlogEntity>> CreateAsync (BlogEntity entity, CancellationToken token);
    Task<Result<bool>> DeleteAsync (int entityId, CancellationToken token);
    Task<Result<BlogEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<Result<BlogEntity?>> GetFileAsync (int entityId, CancellationToken token);
    Task<PagedList<List<BlogEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<PagedList<List<BlogEntity>?>> GetAllPublishAsync (PagedRequest request, CancellationToken token);
    Task<Result<BlogEntity>> UpdateAsync (BlogEntity entity, CancellationToken token);
    Task<Result<List<BlogEntity>?>> SearchAsync (Expression<Func<BlogEntity, bool>> expression, string entity, CancellationToken token);
}
