namespace Kairos.Application.UseCases.Blog.GetById;
public class GetBlogByIdHandler (IBlogRepository repository)
{
    public async Task<Result<GetBlogByIdResponse>> GetByIdHandler(GetBlogByIdCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new Result<GetBlogByIdResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new Result<GetBlogByIdResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetBlogById();
            
            return new Result<GetBlogByIdResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new Result<GetBlogByIdResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}"
                );
        }
    }
}
