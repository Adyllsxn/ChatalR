namespace Kairos.Application.UseCases.TipoEvento.Update;
public class UpdateTipoEventoHandler(ITipoEventoRepository repository, IUnitOfWork unitOfWork )
{
    public async Task<CommandResult<bool>> UpdateHendler(UpdateTipoEventoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToTipoEventoEntity();
            var response = await repository.UpdateAsync(entity, token);
            
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
                message: $"Erro ao manipular a operação (EDITAR). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
                );
        }
    }
}
