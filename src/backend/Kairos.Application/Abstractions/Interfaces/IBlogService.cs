namespace Kairos.Application.Abstractions.Interfaces;
public interface IBlogService
{
    Task<PagedList<List<GetBlogsResponse>?>> GetHandler(GetBlogsCommand command, CancellationToken token);
    Task<QueryResult<GetBlogByIdResponse>> GetByIdHandler(GetBlogByIdCommand command, CancellationToken token);
    Task<QueryResult<GetFileBlogResponse>> GetFileHandler(GetFileBlogCommand command, CancellationToken token);
    Task<PagedList<List<GetBlogsResponse>?>> GetPublishHandler(GetPublishBlogCommand command, CancellationToken token);
    Task<QueryResult<List<GetBlogsResponse>>> SearchHendler(SearchBlogCommand command, CancellationToken token);
    Task<CommandResult<bool>> CreateHandler(CreateBlogCommand command, CancellationToken token);
    Task<CommandResult<bool>> PublishHandler(PublishBlogCommand command, CancellationToken token);
    Task<CommandResult<bool>> UpdateHendler(UpdateBlogCommand command, CancellationToken token);
    Task<CommandResult<bool>> ArchiveHandler(ArchiveBlogCommand command, CancellationToken token);
    Task<CommandResult<bool>> DeleteHandler(DeleteBlogCommand command, CancellationToken token);

}
