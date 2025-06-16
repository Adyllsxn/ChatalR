namespace Kairos.Application.UseCases.Blog.GetAll;
public class GetBlogsHandler(IBlogRepository repository)
{
    public async Task<PagedList<List<GetBlogsResponse>?>> GetHandler(GetBlogsCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetAllAsync(command,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new PagedList<List<GetBlogsResponse>?>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetBlogs().ToList();
            
            return new PagedList<List<GetBlogsResponse>?>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetBlogsResponse>?>(
                null, 
                500, 
                $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}"
                );
        }
    }
}
