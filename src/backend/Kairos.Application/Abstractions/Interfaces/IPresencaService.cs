namespace Kairos.Application.Abstractions.Interfaces;
public interface IPresencaService
{
    Task<Result<CreatePresencaResponse>> CreateHandler(CreatePresencaCommand command, CancellationToken token);
    Task<Result<bool>> DeleteHandler(DeletePresencaCommand command, CancellationToken token);
    Task<PagedList<List<GetPresencaResponse>?>> GetHandler(GetPresencaCommand command, CancellationToken token);
    Task<Result<GetPresencaByIdResponse>> GetByIdHandler(GetPresencaByIdCommand command, CancellationToken token);
}
