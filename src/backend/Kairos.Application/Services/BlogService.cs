namespace Kairos.Application.Services;
public class BlogService(ArchiveBlogHandler archive, CreateBlogHandler create, DeleteBlogHandler delete, GetBlogByIdHandler getById, GetFileBlogHandler getFile, GetBlogsHandler get, GetPublishBlogHandler getPublish, PublishBlogHandler publish, SearchBlogHandler search, UpdateBlogHandler update) : IBlogService
{
    #region GetAll
        public async Task<PagedList<List<GetBlogsResponse>?>> GetHandler(GetBlogsCommand command, CancellationToken token)
        {
            return await get.GetHandler(command, token);
        }
    #endregion
    
    #region GetById
        public async Task<QueryResult<GetBlogByIdResponse>> GetByIdHandler(GetBlogByIdCommand command, CancellationToken token)
        {
            return await getById.GetByIdHandler(command, token);
        }
    #endregion
    
    #region GetFile
        public async Task<QueryResult<GetFileBlogResponse>> GetFileHandler(GetFileBlogCommand command, CancellationToken token)
        {
            return await getFile.GetFileHandler(command, token);
        }
    #endregion
    
    #region GetPublish
        public async Task<PagedList<List<GetBlogsResponse>?>> GetPublishHandler(GetPublishBlogCommand command, CancellationToken token)
        {
            return await getPublish.GetPublishHandler(command, token);
        }
    #endregion
    
    #region Search
        public async Task<QueryResult<List<GetBlogsResponse>>> SearchHendler(SearchBlogCommand command, CancellationToken token)
        {
            return await search.SearchHendler(command, token);
        }
    #endregion
    
    #region Create
        public async Task<CommandResult<bool>> CreateHandler(CreateBlogCommand command, CancellationToken token)
        {
            return await create.CreateHandler(command, token);
        }
    #endregion

    #region Update
        public async Task<CommandResult<bool>> UpdateHendler(UpdateBlogCommand command, CancellationToken token)
        {
            return await update.UpdateHendler(command, token);
        }
    #endregion
    
    #region Publish
        public async Task<CommandResult<bool>> PublishHandler(PublishBlogCommand command, CancellationToken token)
        {
            return await publish.PublishHandler(command, token);
        }
    #endregion
    
    #region Archive
        public async Task<CommandResult<bool>> ArchiveHandler(ArchiveBlogCommand command, CancellationToken token)
        {
            return await archive.ArchiveHandler(command, token);
        }
    #endregion
    
    #region Delete
        public async Task<CommandResult<bool>>  DeleteHandler(DeleteBlogCommand command, CancellationToken token)
        {
            return await delete.DeleteHandler(command, token);
        }
    #endregion

}
