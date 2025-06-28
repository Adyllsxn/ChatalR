namespace Kairos.Application.Abstractions.Interfaces;
public interface IUsuarioService
{
    Task<QueryResult<GetUsuarioByIdResponse>> GetByIdHandler(GetUsuarioByIdCommand command, CancellationToken token);
    Task<QueryResult<GetUsuarioFotoResponse>> GetFotoHandler(GetUsuarioFotoCommand command, CancellationToken token);
    Task<PagedList<List<GetUsuariosResponse>?>> GetHandler(GetUsuariosCommand command, CancellationToken token);
    Task<bool> GetIfExistHandle();
    Task<QueryResult<List<SearchUsuarioResponse>>> SearchHendler(SearchUsuarioCommand command, CancellationToken token);
    
    Task<CommandResult<bool>> CreateHandler(CreateUsuarioCommand command, CancellationToken token);
    Task<CommandResult<bool>> UpdateHandler(UpdateUsuarioCommand command, CancellationToken token);
    Task<CommandResult<bool>> UpdateFotoHandler(UpdateUsuarioFotoCommand command, CancellationToken token);
    Task<CommandResult<bool>> StatusHandler(UsuarioStatusCommand command, CancellationToken token);
    Task<CommandResult<bool>> DeleteHandler(DeleteUsuarioCommand command, CancellationToken token);
}
