namespace Kairos.Application.Abstractions.Interfaces;
public interface IEventoService
{
    Task<Result<CreateEventoResponse>> CreateHandler(CreateEventoCommand command, CancellationToken token);
    Task<Result<GetFileEventoResponse>> GetFileHandler(GetFileEventoCommand command, CancellationToken token);
    Task<Result<GetEventoByIdResponse>> GetByIdHandler(GetEventoByIdCommand command, CancellationToken token);
    Task<PagedList<List<GetEventosResponse>?>> GetHandler(GetEventosCommand command, CancellationToken token);
    Task<Result<bool>> DeleteHandler(DeleteEventoCommand command, CancellationToken token);
    Task<Result<List<SearchEventoResponse>>> SearchHendler(SearchEventoCommand command, CancellationToken token);
    Task<Result<UpdateEventoResponse>> UpdateHendler(UpdateEventoCommand command, CancellationToken token);
    Task<Result<UpdateEventoStatusResponse>> StatusHandler(UpdateEventoStatusCommand command, CancellationToken token);
}
