namespace Kairos.Application.UseCases.Evento.Status;
public class UpdateEventoStatusHandler(IEventoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<UpdateEventoStatusResponse>> StatusHandler(UpdateEventoStatusCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);

            if (resultEntity == null || resultEntity.Data == null)
                return new Result<UpdateEventoStatusResponse>(null, 404, "Evento não encontrado.");

            var entity = resultEntity.Data;

            entity.AtualizarStatus(command.StatusAprovacao);

            await unitOfWork.CommitAsync();

            var response = entity.MapToUpdateStatusResponse(); 

            return new Result<UpdateEventoStatusResponse>(response, 200, "Status atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return new Result<UpdateEventoStatusResponse>(null, 500, $"Erro ao atualizar status: {ex.Message}");
        }
    }
}
