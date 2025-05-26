namespace Kairos.Application.Services;
public class EventoService(CreateEventoHandler create, DeleteEventoHandler delete,GetEventosHandler get ,GetFileEventoHandler getFile, GetEventoByIdHandler getById, SearchEventoHandler search, UpdateEventoHandler update, UpdateEventoStatusHandler updateStatus) : IEventoService
{
    public async Task<Result<CreateEventoResponse>> CreateHandler(CreateEventoCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<Result<bool>> DeleteHandler(DeleteEventoCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }

    public async Task<Result<GetEventoByIdResponse>> GetByIdHandler(GetEventoByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<Result<GetFileEventoResponse>> GetFileHandler(GetFileEventoCommand command, CancellationToken token)
    {
        return await getFile.GetFileHandler(command, token);
    }

    public async Task<PagedList<List<GetEventosResponse>?>> GetHandler(GetEventosCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }

    public async Task<Result<List<SearchEventoResponse>>> SearchHendler(SearchEventoCommand command, CancellationToken token)
    {
        return await search.SearchHendler(command, token);
    }

    public async Task<Result<UpdateEventoStatusResponse>> StatusHandler(UpdateEventoStatusCommand command, CancellationToken token)
    {
        return await updateStatus.StatusHandler(command, token);
    }

    public async Task<Result<UpdateEventoResponse>> UpdateHendler(UpdateEventoCommand command, CancellationToken token)
    {
        return await update.UpdateHendler(command, token);
    }
}
