namespace Kairos.Application.UseCases.Evento.Update;
public class UpdateEventoHandler(IEventoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<UpdateEventoResponse>> UpdateHendler(UpdateEventoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToEventoEntity();
            var response = await repository.UpdateAsync(entity, token);
            await unitOfWork.CommitAsync();

            return new Result<UpdateEventoResponse>(
                response.Data?.MapToUpdateEvento(),
                response.Code,
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new Result<UpdateEventoResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (UPDATE). Erro: {ex.Message}"
                );
        }
    }
}
