namespace Kairos.Application.UseCases.Presenca.Create;
public class CreatePresencaHandler(IPresencaRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<CreatePresencaResponse>> CreateHandler(CreatePresencaCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToPresencaEntity();
            var response = await repository.CreateAsync(entity, token);
            await unitOfWork.CommitAsync();

            return new Result<CreatePresencaResponse>(
                response.Data?.MapToCreatePresenca(), 
                response.Code, 
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new Result<CreatePresencaResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (CRIAR). Erro: {ex.Message}"
                );
        }
    }
}
