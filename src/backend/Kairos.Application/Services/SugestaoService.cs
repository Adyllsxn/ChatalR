namespace Kairos.Application.Services;
public class SugestaoService(CreateSugestaoHandler create, DeleteSugestaoHandler delete, GetSugestaoHandler get, GetReadSugestaoHandler getRead, GetUnReadSugestaoHandler getUnRead, GetSugestaoByIdHandler getById, MarkAsReadSugestaoHandler mark, UpdateSugestaoHandler update) : ISugestaoService
{
    public async Task<Result<CreateSugestaoResponse>> CreateHandler(CreateSugestaoCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<Result<bool>> DeleteHandler(DeleteSugestaoCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }

    public async Task<PagedList<List<GetSugestaoResponse>?>> GetAllReadHandler(GetSugestaoCommand command, CancellationToken token)
    {
        return await getRead.GetAllReadHandler(command, token);
    }

    public async Task<PagedList<List<GetSugestaoResponse>?>> GetAllUnreadHandler(GetSugestaoCommand command, CancellationToken token)
    {
        return await getUnRead.GetAllUnreadHandler(command, token);
    }

    public async Task<Result<GetSugestaoByIdResponse>> GetByIdHandler(GetSugestaoByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<PagedList<List<GetSugestaoResponse>?>> GetHandler(GetSugestaoCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }

    public async Task<Result<bool>> MarkAsReadHandler(MarkAsReadSugestaoCommand command, CancellationToken token)
    {
        return await mark.MarkAsReadHandler(command, token);
    }

    public async Task<Result<UpdateSugestaoResponse>> UpdateHendler(UpdateSugestaoCommand command, CancellationToken token)
    {
        return await update.UpdateHendler(command, token);
    }
}
