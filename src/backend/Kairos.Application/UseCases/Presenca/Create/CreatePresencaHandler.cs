namespace Kairos.Application.UseCases.Presenca.Create;
public class CreatePresencaHandler(IPresencaRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> CreateHandler(CreatePresencaCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToPresencaEntity();
            var response = await repository.CreateAsync(entity, token);
            await unitOfWork.CommitAsync(token);
            return CommandResult<bool>.Success(
                value: true,
                message: response.Message,
                code: response.Code
            );
        }
        catch (Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (CRIAR). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
            );
        }
    }

}
