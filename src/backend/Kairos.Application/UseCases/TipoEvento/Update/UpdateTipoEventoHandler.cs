namespace Kairos.Application.UseCases.TipoEvento.Update;
public class UpdateTipoEventoHandler(ITipoEventoRepository repository, IUnitOfWork unitOfWork )
{
    public async Task<Result<UpdateTipoEventoResponse>> UpdateHendler(UpdateTipoEventoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToTipoEventoEntity();
            var response = await repository.UpdateAsync(entity, token);
            await unitOfWork.CommitAsync();

            return new Result<UpdateTipoEventoResponse>(
                response.Data?.MapToUpdateTipoEvento(),
                response.Code,
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new Result<UpdateTipoEventoResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (UPDATE). Erro: {ex.Message}"
                );
        }
    }
}
