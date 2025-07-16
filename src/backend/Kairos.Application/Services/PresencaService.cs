
namespace Kairos.Application.Services;
public class PresencaService(CreatePresencaHandler create, DeletePresencaHandler delete, GetPresencaHandler get, GetPresencaByIdHandler getById, SearchPresencaHandler search) : IPresencaService
{
    #region GetAll
    public async Task<PagedList<List<GetPresencaResponse>?>> GetHandler(GetPresencaCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }
    #endregion

    #region GetById
    public async Task<QueryResult<GetPresencaByIdResponse>> GetByIdHandler(GetPresencaByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }
    #endregion

    #region Create
    public async Task<CommandResult<bool>> CreateHandler(CreatePresencaCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }
    #endregion

    #region Delete
    public async Task<CommandResult<bool>> DeleteHandler(DeletePresencaCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }
    #endregion

    #region Search
        public async Task<QueryResult<List<SearchPresencaResponse>>> SearchHendler(SearchPresencaCommand command, CancellationToken token)
        {
            return await search.SearchHendler(command, token);
        }
    #endregion
}
