namespace Kairos.Application.UseCases.Blog.Archive;
public class ArchiveBlogHandler(IBlogRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> ArchiveHandler(ArchiveBlogCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);
            if (resultEntity == null || resultEntity.Data == null)
            {
                return CommandResult<bool>.Failure(
                    value: false,
                    message: "Post não encontrado",
                    code: StatusCode.NotFound
                    );
            }

            var entity = resultEntity.Data;
            entity.Arquivar();

            await unitOfWork.CommitAsync(token);
            return CommandResult<bool>.Success(
                value: true,
                message: "Post arquivado com sucesso",
                code: StatusCode.NoContent
                );
        }

        catch (Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (ARQUIVAR). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
                );
        }
    }
}
