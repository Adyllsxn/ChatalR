namespace Kairos.Application.UseCases.Sugestao.MarkAsRead;
public class MarkAsReadSugestaoHandler(ISugestaoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<bool>> MarkAsReadHandler(MarkAsReadSugestaoCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.MarkAsReadAsync(command.Id, token);
            await unitOfWork.CommitAsync();
            return new Result<bool>(
                response.Data,
                response.Code,
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new Result<bool>(
                false,
                500,
                $"Erro ao manipular a operação (LIDA). Erro: {ex.Message}"
            );
        }
    }
}
