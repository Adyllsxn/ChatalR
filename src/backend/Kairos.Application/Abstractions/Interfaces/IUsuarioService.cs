namespace Kairos.Application.Abstractions.Interfaces;
public interface IUsuarioService
{
    Task<Result<CreateUsuarioResponse>> CreateHandler(CreateUsuarioCommand command, CancellationToken token);
    Task<Result<bool>> DeleteHandler(DeleteUsuarioCommand command, CancellationToken token);
    Task<PagedList<List<GetUsuariosResponse>?>> GetHandler(GetUsuariosCommand command, CancellationToken token);
    Task<Result<GetUsuarioByIdResponse>> GetByIdHandler(GetUsuarioByIdCommand command, CancellationToken token);
    Task<bool> GetIfExistHandle();
    Task<Result<List<SearchUsuarioResponse>>> SearchHendler(SearchUsuarioCommand command, CancellationToken token);
    Task<Result<UsuarioStatusResponse>> StatusHandler(UsuarioStatusCommand command, CancellationToken token);
    Task<Result<UpdateUsuarioResponse>> UpdateHandler(UpdateUsuarioCommand command, CancellationToken token);
}
