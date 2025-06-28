namespace Kairos.Application.UseCases.Blog.GetPublish;
public class GetPublishBlogHandler(IBlogRepository repository)
{
    public async Task<PagedList<List<GetBlogsResponse>?>> GetPublishHandler(GetPublishBlogCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetAllPublishAsync(command,token);
            if (response.Data == null || !response.Data.Any())
            {
                return new PagedList<List<GetBlogsResponse>?>(
                    data: null,
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetBlogs().ToList();
            return new PagedList<List<GetBlogsResponse>?>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetBlogsResponse>?>(
                data: null, 
                message: $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
