namespace Kairos.Application.Abstractions.Interfaces;
public interface IBlogService
{
    Task<Result<ArchiveBlogResponse>> ArchiveHandler(ArchiveBlogCommand command, CancellationToken token);
    Task<Result<CreateBlogResponse>> CreateHandler(CreateBlogCommand command, CancellationToken token);
    Task<Result<bool>> DeleteHandler(DeleteBlogCommand command, CancellationToken token);
    Task<PagedList<List<GetBlogsResponse>?>> GetHandler(GetBlogsCommand command, CancellationToken token);
    Task<Result<GetBlogByIdResponse>> GetByIdHandler(GetBlogByIdCommand command, CancellationToken token);
    Task<Result<GetFileBlogResponse>> GetFileHandler(GetFileBlogCommand command, CancellationToken token);
    Task<PagedList<List<GetBlogsResponse>?>> GetPublishHandler(GetPublishBlogCommand command, CancellationToken token);
    Task<Result<PublishBlogResponse>> PublishHandler(PublishBlogCommand command, CancellationToken token);
    Task<Result<List<GetBlogsResponse>>> SearchHendler(SearchBlogCommand command, CancellationToken token);
    Task<Result<UpdateBlogResponse>> UpdateHendler(UpdateBlogCommand command, CancellationToken token);
}
