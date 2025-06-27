

namespace Kairos.Application.UseCases.TipoEvento.Create;
public class CreateTipoEventoHandler(ITipoEventoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> CreateHandler(CreateTipoEventoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToTipoEventoEntity();
            var response = await repository.CreateAsync(entity, token);
            await unitOfWork.CommitAsync();

            /*return new CommandResult<bool>(
                response.Data?.MapToCreateTipoEvento(), 
                response.Code, 
                response.Message
            );*/
            return CommandResult<bool>.Success(
                value: true,
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            /*return new CommandResult<bool>(
                null, 
                500, 
                $"Erro ao manipular a operação (CRIAR). Erro: {ex.Message}"
                );*/
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (CRIAR). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
    }
    }
}
