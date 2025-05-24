namespace Kairos.Application.Services;
public class UsuarioService( CreateUsuarioHandler create, DeleteUsuarioHandler delete, GetUsuariosHandler get, GetUsuarioByIdHandler getById, SearchUsuarioHandler search, UpdateUsuarioHandler update, ExistUsuarioHandler exist) : IUsuarioService
{
    public async Task<Result<CreateUsuarioResponse>> CreateHandler(CreateUsuarioCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<Result<bool>> DeleteHandler(DeleteUsuarioCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }

    public async Task<Result<GetUsuarioByIdResponse>> GetByIdHandler(GetUsuarioByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<PagedList<List<GetUsuariosResponse>?>> GetHandler(GetUsuariosCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }

    public async Task<bool> GetIfExistHandle()
    {
        return await exist.GetIfExistHandle();
    }

    public async Task<Result<List<SearchUsuarioResponse>>> SearchHendler(SearchUsuarioCommand command, CancellationToken token)
    {
        return await search.SearchHendler(command, token);
    }

    public async Task<Result<UpdateUsuarioResponse>> UpdateHendler(UpdateUsuarioCommand command, CancellationToken token)
    {
        return await update.UpdateHendler(command, token);
    }
}