namespace Kairos.Infrastructure.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    public Task<Result<UsuarioEntity>> CreateAsync(UsuarioEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> DeleteAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<List<UsuarioEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UsuarioEntity?>> GetByIdAsync(int entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> GetIfUserExistAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<UsuarioEntity>?>> SearchAsync(Expression<Func<UsuarioEntity, bool>> expression, string entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UsuarioEntity>> UpdateAsync(UsuarioEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
