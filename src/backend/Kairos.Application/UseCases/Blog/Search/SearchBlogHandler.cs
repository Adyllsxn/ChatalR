namespace Kairos.Application.UseCases.Blog.Search;
public class SearchBlogHandler(IBlogRepository repository)
{
    public async Task<QueryResult<List<GetBlogsResponse>>> SearchHendler(SearchBlogCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.SearchAsync(x => x.Titulo.Contains(command.Titulo),string.Empty,token);
            if (response.Data == null || !response.Data.Any())
            {
                return new QueryResult<List<GetBlogsResponse>>(
                    data: null, 
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetBlogs().ToList();
            return new QueryResult<List<GetBlogsResponse>>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch (Exception ex)
        {
            return new QueryResult<List<GetBlogsResponse>>(
                data: null, 
                message: $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
