namespace Kairos.Application.UseCases.Sugestao.Create;
public class CreateSugestaoHandler(ISugestaoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<CreateSugestaoResponse>> CreateHandler(CreateSugestaoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToSugestaoEntity();
            var response = await repository.CreateAsync(entity, token);
            await unitOfWork.CommitAsync();

            return new Result<CreateSugestaoResponse>(
                response.Data?.MapToCreateSugestao(), 
                response.Code, 
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new Result<CreateSugestaoResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (CRIAR). Erro: {ex.Message}"
                );
        }
    }
}
