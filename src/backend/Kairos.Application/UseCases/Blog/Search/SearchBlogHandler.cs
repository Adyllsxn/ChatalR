namespace Kairos.Application.UseCases.Blog.Search;
public class SearchBlogHandler(IBlogRepository repository)
{
    public async Task<Result<List<GetBlogsResponse>>> SearchHendler(SearchBlogCommand command, CancellationToken token)
    {
        try
        {
            if(command.Titulo == null)
            {
                return new Result<List<GetBlogsResponse>>(
                    null, 
                    400, 
                    "Parâmetro não deve estar vazio."
                    );
            }
            var response = await repository.SearchAsync(x => x.Titulo.Contains(command.Titulo),string.Empty,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new Result<List<GetBlogsResponse>>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetBlogs().ToList();
            
            return new Result<List<GetBlogsResponse>>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new Result<List<GetBlogsResponse>>(
                null, 
                500, 
                $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}"
                );
        }
    }
}
