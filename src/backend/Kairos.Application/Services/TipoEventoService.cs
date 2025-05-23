namespace Kairos.Application.Services;
public class TipoEventoService(CreateTipoEventoHandler create,DeleteTipoEventoHandler delete, GetTipoEventosHandler get, GetTipoEventoByIdHandler getById, SearchTipoEventoHandler search, UpdateTipoEventoHandler update) : ITipoEventoService
{
    public async Task<Result<CreateTipoEventoResponse>> CreateHandler(CreateTipoEventoCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<Result<bool>> DeleteHandler(DeleteTipoEventoCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }

    public async Task<Result<GetTipoEventoByIdResponse>> GetByIdHandler(GetTipoEventoByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<PagedList<List<GetTipoEventosResponse>?>> GetHandler(GetTipoEventosCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }

    public async Task<Result<List<SearchTipoEventoResponse>>> SearchHendler(SearchTipoEventoCommand command, CancellationToken token)
    {
        return await search.SearchHendler(command, token);
    }

    public async Task<Result<UpdateTipoEventoResponse>> UpdateHendler(UpdateTipoEventoCommand command, CancellationToken token)
    {
        return await update.UpdateHendler(command, token);
    }
}
