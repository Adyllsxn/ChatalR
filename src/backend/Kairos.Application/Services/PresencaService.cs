namespace Kairos.Application.Services;
public class PresencaService(CreatePresencaHandler create, DeletePresencaHandler delete, GetPresencaHandler get, GetPresencaByIdHandler getById ) : IPresencaService
{
    public async Task<Result<CreatePresencaResponse>> CreateHandler(CreatePresencaCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<Result<bool>> DeleteHandler(DeletePresencaCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }

    public async Task<Result<GetPresencaByIdResponse>> GetByIdHandler(GetPresencaByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<PagedList<List<GetPresencaResponse>?>> GetHandler(GetPresencaCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }
}
