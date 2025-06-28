namespace Kairos.Application.UseCases.Blog.GetFile;
public class GetFileBlogHandler(IBlogRepository repository)
{
    public async Task<QueryResult<GetFileBlogResponse>> GetFileHandler(GetFileBlogCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetFileAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetFileBlogResponse>(
                    data: null,
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetFileBlog();
            return new QueryResult<GetFileBlogResponse>(
                data: result,
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetFileBlogResponse>(
                data: null,  
                message: $"Erro ao manipular a operação (GET FILE). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
