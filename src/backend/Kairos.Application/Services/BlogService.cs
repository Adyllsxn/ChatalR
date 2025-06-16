namespace Kairos.Application.Services;
public class BlogService(ArchiveBlogHandler archive, CreateBlogHandler create, DeleteBlogHandler delete, GetBlogByIdHandler getById, GetFileBlogHandler getFile, GetBlogsHandler get, GetPublishBlogHandler getPublish, PublishBlogHandler publish, SearchBlogHandler search, UpdateBlogHandler update) : IBlogService
{
    public async Task<Result<ArchiveBlogResponse>> ArchiveHandler(ArchiveBlogCommand command, CancellationToken token)
    {
        return await archive.ArchiveHandler(command, token);
    }

    public async Task<Result<CreateBlogResponse>> CreateHandler(CreateBlogCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<Result<bool>> DeleteHandler(DeleteBlogCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }

    public async Task<Result<GetBlogByIdResponse>> GetByIdHandler(GetBlogByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<Result<GetFileBlogResponse>> GetFileHandler(GetFileBlogCommand command, CancellationToken token)
    {
        return await getFile.GetFileHandler(command, token);
    }

    public async Task<PagedList<List<GetBlogsResponse>?>> GetHandler(GetBlogsCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }

    public async Task<PagedList<List<GetBlogsResponse>?>> GetPublishHandler(GetPublishBlogCommand command, CancellationToken token)
    {
        return await getPublish.GetPublishHandler(command, token);
    }

    public async Task<Result<PublishBlogResponse>> PublishHandler(PublishBlogCommand command, CancellationToken token)
    {
        return await publish.PublishHandler(command, token);
    }

    public async Task<Result<List<GetBlogsResponse>>> SearchHendler(SearchBlogCommand command, CancellationToken token)
    {
        return await search.SearchHendler(command, token);
    }

    public async Task<Result<UpdateBlogResponse>> UpdateHendler(UpdateBlogCommand command, CancellationToken token)
    {
        return await update.UpdateHendler(command, token);
    }
}
