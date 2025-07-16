namespace Kairos.Application.Abstractions.Interfaces;
public interface IPresencaService
{
    Task<PagedList<List<GetPresencaResponse>?>> GetHandler(GetPresencaCommand command, CancellationToken token);
    Task<QueryResult<GetPresencaByIdResponse>> GetByIdHandler(GetPresencaByIdCommand command, CancellationToken token);
    Task<CommandResult<bool>> CreateHandler(CreatePresencaCommand command, CancellationToken token);
    Task<CommandResult<bool>> DeleteHandler(DeletePresencaCommand command, CancellationToken token);
    Task<QueryResult<List<SearchPresencaResponse>>> SearchHendler(SearchPresencaCommand command, CancellationToken token);
}
