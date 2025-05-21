namespace Kairos.Infrastructure.Repositories;
public class SugestaoRepository : ISugestaoRepository
{
    public Task<Result<SugestaoEntity>> CreateAsync(SugestaoEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> DeleteAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<List<SugestaoEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<SugestaoEntity?>> GetByIdAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<SugestaoEntity>> UpdateAsync(SugestaoEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
