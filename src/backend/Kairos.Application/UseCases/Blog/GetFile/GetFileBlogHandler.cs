namespace Kairos.Application.UseCases.Blog.GetFile;
public class GetFileBlogHandler(IBlogRepository repository)
{
    public async Task<Result<GetFileBlogResponse>> GetFileHandler(GetFileBlogCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new Result<GetFileBlogResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetFileAsync(command.Id, token);
            if (response.Data == null)
            {
                return new Result<GetFileBlogResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetFileBlog();
            
            return new Result<GetFileBlogResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new Result<GetFileBlogResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET FILE). Erro: {ex.Message}"
                );
        }
    }
}
