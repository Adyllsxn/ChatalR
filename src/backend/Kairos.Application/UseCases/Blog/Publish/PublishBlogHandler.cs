namespace Kairos.Application.UseCases.Blog.Publish;
public class PublishBlogHandler(IBlogRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> PublishHandler(PublishBlogCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);
            if (resultEntity == null || resultEntity.Data == null)
            {
                return CommandResult<bool>.Failure(
                    value: false,
                    message: $"Evento não encontrado.",
                    code: StatusCode.NotFound
                    );
            }

            var entity = resultEntity.Data;
            entity.Publicar();

            await unitOfWork.CommitAsync(token);
            return CommandResult<bool>.Success(
                value: true,
                message: "Post publicado com sucesso",
                code: StatusCode.NoContent
                );
        }

        catch (Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (PUBLICAR). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
                );
        }
    }
}
