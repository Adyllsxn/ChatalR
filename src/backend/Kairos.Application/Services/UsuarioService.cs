namespace Kairos.Application.Services;
public class UsuarioService( CreateUsuarioHandler create, DeleteUsuarioHandler delete, GetUsuariosHandler get, GetUsuarioByIdHandler getById, GetUsuarioFotoHandler getFoto, SearchUsuarioHandler search, ExistUsuarioHandler exist, UsuarioStatusHandler statusHandler, UpdateUsuarioHandler update, UpdateUsuarioFotoHandler updateFoto) : IUsuarioService
{
    #region GetAll
        public async Task<PagedList<List<GetUsuariosResponse>?>> GetHandler(GetUsuariosCommand command, CancellationToken token)
        {
            return await get.GetHandler(command, token);
        }
    #endregion
    
    #region GetById
        public async Task<QueryResult<GetUsuarioByIdResponse>> GetByIdHandler(GetUsuarioByIdCommand command, CancellationToken token)
        {
            return await getById.GetByIdHandler(command, token);
        }
    #endregion
    
    #region GetFoto
        public async Task<QueryResult<GetUsuarioFotoResponse>> GetFotoHandler(GetUsuarioFotoCommand command, CancellationToken token)
        {
            return await getFoto.GetFotoHandler(command, token);
        }
    #endregion

    #region GetIfExist
        public async Task<bool> GetIfExistHandle()
        {
            return await exist.GetIfExistHandle();
        }
    #endregion

    #region Search
        public async Task<QueryResult<List<SearchUsuarioResponse>>> SearchHendler(SearchUsuarioCommand command, CancellationToken token)
        {
            return await search.SearchHendler(command, token);
        }
    #endregion

    #region Create
        public async Task<CommandResult<bool>> CreateHandler(CreateUsuarioCommand command, CancellationToken token)
        {
            return await create.CreateHandler(command, token);
        }
    #endregion
    
    #region Update
        public async Task<CommandResult<bool>> UpdateHandler(UpdateUsuarioCommand command, CancellationToken token)
        {
            return await update.UpdateHandler(command, token);
        }
    #endregion

    #region UpdateFoto
        public async Task<CommandResult<bool>> UpdateFotoHandler(UpdateUsuarioFotoCommand command, CancellationToken token)
        {
            return await updateFoto.UpdateFotoHandler(command, token);
        }
    #endregion

    #region Status
        public async Task<CommandResult<bool>> StatusHandler(UsuarioStatusCommand command, CancellationToken token)
        {
            return await statusHandler.StatusHandler(command, token);
        }
    #endregion

    #region Delete
        public async Task<CommandResult<bool>> DeleteHandler(DeleteUsuarioCommand command, CancellationToken token)
        {
            return await delete.DeleteHandler(command, token);
        }
    #endregion
    
}