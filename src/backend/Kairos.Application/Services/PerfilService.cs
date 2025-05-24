namespace Kairos.Application.Services;
public class PerfilService(GetPerfilsHandler get, GetPerfilByIdHandler getById, SearchPerfilHandler search) : IPerfilService
{
    public async Task<Result<GetPerfilByIdResponse>> GetByIdHandler(GetPerfilByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<Result<List<GetPerfilsResponse>>> GetHandler(CancellationToken token)
    {
        return await get.GetHandler(token);
    }

    public async Task<Result<List<SearchPerfilResponse>>> SearchHendler(SearchPerfilCommand command, CancellationToken token)
    {
        return await search.SearchHendler(command, token);
    }
}
