namespace Kairos.Application.Abstractions.Interfaces;
public interface ISugestaoService
{
    Task<Result<CreateSugestaoResponse>> CreateHandler(CreateSugestaoCommand command, CancellationToken token);
    Task<Result<bool>> DeleteHandler(DeleteSugestaoCommand command, CancellationToken token);
    Task<PagedList<List<GetSugestaoResponse>?>> GetHandler(GetSugestaoCommand command, CancellationToken token);
    Task<Result<GetSugestaoByIdResponse>> GetByIdHandler(GetSugestaoByIdCommand command, CancellationToken token);
    Task<PagedList<List<GetSugestaoResponse>?>> GetAllReadHandler(GetSugestaoCommand command, CancellationToken token);
    Task<PagedList<List<GetSugestaoResponse>?>> GetAllUnreadHandler(GetSugestaoCommand command, CancellationToken token);
    Task<Result<bool>> MarkAsReadHandler(MarkAsReadSugestaoCommand command, CancellationToken token);
    Task<Result<UpdateSugestaoResponse>> UpdateHendler(UpdateSugestaoCommand command, CancellationToken token);
}
