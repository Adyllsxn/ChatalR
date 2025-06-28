namespace Kairos.Application.UseCases.Usuario.Delete;
public class DeleteUsuarioHandler(IUsuarioRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> DeleteHandler(DeleteUsuarioCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.DeleteAsync(command.Id, token);
            await unitOfWork.CommitAsync(token);
            return CommandResult<bool>.Success(
                value: true,
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (EXCLUIR). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
                );
        }
    }
}