namespace Kairos.Infrastructure.Repositories;
public class PresencaRepository : IPresencaRepository
{
    public Task<Result<PresencaEntity>> CreateAsync(PresencaEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> DeleteAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<List<PresencaEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<PresencaEntity?>> GetByIdAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<PresencaEntity>> UpdateAsync(PresencaEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
