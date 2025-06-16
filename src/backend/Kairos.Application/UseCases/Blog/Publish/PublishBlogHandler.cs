namespace Kairos.Application.UseCases.Blog.Publish;
public class PublishBlogHandler(IBlogRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<PublishBlogResponse>> PublishHandler(PublishBlogCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);

            if (resultEntity == null || resultEntity.Data == null)
                return new Result<PublishBlogResponse>(null, 404, "Evento não encontrado.");

            var entity = resultEntity.Data;

            entity.Arquivar();

            await unitOfWork.CommitAsync();

            var response = entity.MapToPublishPostagem(); 

            return new Result<PublishBlogResponse>(response, 200, "Status atualizado com sucesso.");
        }

        catch (Exception ex)
        {
            return new Result<PublishBlogResponse>(null, 500, $"Erro ao atualizar status: {ex.Message}");
        }
    }
}
