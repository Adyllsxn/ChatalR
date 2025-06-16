namespace Kairos.Application.UseCases.Blog.Create;
public class CreateBlogHandler(IBlogRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<CreateBlogResponse>> CreateHandler(CreateBlogCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToBlogEntity();
            var response = await repository.CreateAsync(entity, token);
            await unitOfWork.CommitAsync();

            return new Result<CreateBlogResponse>(
                response.Data?.MapToCreateBlog(), 
                response.Code, 
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new Result<CreateBlogResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (CRIAR). Erro: {ex.Message}"
                );
        }
    }
}
