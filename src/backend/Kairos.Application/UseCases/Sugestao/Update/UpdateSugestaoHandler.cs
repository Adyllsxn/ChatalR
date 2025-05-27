namespace Kairos.Application.UseCases.Sugestao.Update;
public class UpdateSugestaoHandler(ISugestaoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<UpdateSugestaoResponse>> UpdateHendler(UpdateSugestaoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToSugestaoEntity();
            var response = await repository.UpdateAsync(entity, token);
            await unitOfWork.CommitAsync();

            return new Result<UpdateSugestaoResponse>(
                response.Data?.MapToUpdateSugestao(),
                response.Code,
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new Result<UpdateSugestaoResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (UPDATE). Erro: {ex.Message}"
                );
        }
    }
}
