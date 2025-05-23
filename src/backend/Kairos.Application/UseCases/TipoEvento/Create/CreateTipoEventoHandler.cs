namespace Kairos.Application.UseCases.TipoEvento.Create;
public class CreateTipoEventoHandler(ITipoEventoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<CreateTipoEventoResponse>> CreateHandler(CreateTipoEventoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToTipoEventoEntity();
            var response = await repository.CreateAsync(entity, token);
            await unitOfWork.CommitAsync();

            return new Result<CreateTipoEventoResponse>(
                response.Data?.MapToCreateTipoEvento(), 
                response.Code, 
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new Result<CreateTipoEventoResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (CRIAR). Erro: {ex.Message}"
                );
        }
    }
}
