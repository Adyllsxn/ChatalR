namespace Kairos.Application.UseCases.Blog.GetById;
public class GetBlogByIdHandler (IBlogRepository repository)
{
    public async Task<QueryResult<GetBlogByIdResponse>> GetByIdHandler(GetBlogByIdCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetBlogByIdResponse>(
                    data:  null,
                    message: response.Message,
                    code: response.Code
                    );
            }

            var result = response.Data.MapToGetBlogById();
            return new QueryResult<GetBlogByIdResponse>(
                data: result, 
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetBlogByIdResponse>(
                data: null, 
                message: $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
