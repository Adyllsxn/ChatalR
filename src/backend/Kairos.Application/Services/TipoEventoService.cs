namespace Kairos.Application.Services;
public class TipoEventoService(CreateTipoEventoHandler create,DeleteTipoEventoHandler delete, GetTipoEventosHandler get, GetTipoEventoByIdHandler getById, SearchTipoEventoHandler search, UpdateTipoEventoHandler update) : ITipoEventoService
{
    public async Task<CommandResult<bool>> CreateHandler(CreateTipoEventoCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<QueryResult<bool>> DeleteHandler(DeleteTipoEventoCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }

    public async Task<QueryResult<GetTipoEventoByIdResponse>> GetByIdHandler(GetTipoEventoByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<PagedList<List<GetTipoEventosResponse>?>> GetHandler(GetTipoEventosCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }

    public async Task<QueryResult<List<SearchTipoEventoResponse>>> SearchHendler(SearchTipoEventoCommand command, CancellationToken token)
    {
        return await search.SearchHendler(command, token);
    }

    public async Task<QueryResult<UpdateTipoEventoResponse>> UpdateHendler(UpdateTipoEventoCommand command, CancellationToken token)
    {
        return await update.UpdateHendler(command, token);
    }
}
