namespace Kairos.Domain.Abstrations.Interfaces;
public interface IPresencaRepository
{
    Task<QueryResult<PresencaEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<PagedList<List<PresencaEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<CommandResult<bool>> CreateAsync (PresencaEntity entity, CancellationToken token);
    Task<CommandResult<bool>> DeleteAsync (int entityId, CancellationToken token);
    Task<bool> ExistePresencaNoMesmoHorario(int usuarioId, int eventoId, CancellationToken token);

}
