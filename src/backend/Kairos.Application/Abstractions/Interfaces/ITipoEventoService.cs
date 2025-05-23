namespace Kairos.Application.Abstractions.Interfaces;
public interface ITipoEventoService
{
    Task<Result<CreateTipoEventoResponse>> CreateHandler(CreateTipoEventoCommand command, CancellationToken token);
    Task<Result<bool>> DeleteHandler(DeleteTipoEventoCommand command, CancellationToken token);
    Task<PagedList<List<GetTipoEventosResponse>?>> GetHandler(GetTipoEventosCommand command, CancellationToken token);
    Task<Result<GetTipoEventoByIdResponse>> GetByIdHandler(GetTipoEventoByIdCommand command, CancellationToken token);
    Task<Result<List<SearchTipoEventoResponse>>> SearchHendler(SearchTipoEventoCommand command, CancellationToken token);
    Task<Result<UpdateTipoEventoResponse>> UpdateHendler(UpdateTipoEventoCommand command, CancellationToken token);
}
