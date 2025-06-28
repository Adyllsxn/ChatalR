namespace Kairos.Domain.Abstrations.Interfaces;
public interface IUsuarioRepository
{
    Task<PagedList<List<UsuarioEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<QueryResult<UsuarioEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<QueryResult<UsuarioEntity?>> GetFotoAsync (int entityId, CancellationToken token);
    Task<bool> GetIfUserExistAsync();
    Task<bool> GetIfExistAsync();
    Task<QueryResult<List<UsuarioEntity>?>> SearchAsync (Expression<Func<UsuarioEntity, bool>> expression, string entity, CancellationToken token);
    Task<CommandResult<bool>> UpdateAsync (UsuarioEntity entity, CancellationToken token);
    Task<CommandResult<bool>> CreateAsync (UsuarioEntity entity, CancellationToken token);
    Task<CommandResult<bool>> DeleteAsync (int entityId, CancellationToken token);
    
}
