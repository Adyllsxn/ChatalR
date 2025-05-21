namespace Kairos.Infrastructure.Repositories;
public class PerfilRepository : IPerfilRepository
{
    public Task<Result<PerfilEntity>> CreateAsync(PerfilEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> DeleteAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<PerfilEntity>?>> GetAllAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<PerfilEntity?>> GetByIdAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<PerfilEntity>?>> SearchAsync(Expression<Func<PerfilEntity, bool>> expression, string entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<PerfilEntity>> UpdateAsync(PerfilEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
