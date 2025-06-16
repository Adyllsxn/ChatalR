namespace Kairos.Application.UseCases.Blog.Archive;
public class ArchiveBlogHandler(IBlogRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<ArchiveBlogResponse>> ArchiveHandler(ArchiveBlogCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);

            if (resultEntity == null || resultEntity.Data == null)
                return new Result<ArchiveBlogResponse>(null, 404, "Evento não encontrado.");

            var entity = resultEntity.Data;

            entity.Arquivar();

            await unitOfWork.CommitAsync();

            var response = entity.MapToArchivePostagem(); 

            return new Result<ArchiveBlogResponse>(response, 200, "Status atualizado com sucesso.");
        }

        catch (Exception ex)
        {
            return new Result<ArchiveBlogResponse>(null, 500, $"Erro ao atualizar status: {ex.Message}");
        }
    }
}
