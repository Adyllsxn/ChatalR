namespace Kairos.Application.UseCases.Usuario.Update;
public class UpdateUsuarioHandler(IUsuarioRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<UpdateUsuarioResponse>> UpdateHendler(UpdateUsuarioCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToUsuarioEntity();
            var response = await repository.UpdateAsync(entity, token);
            await unitOfWork.CommitAsync();

            return new Result<UpdateUsuarioResponse>(
                response.Data?.MapToUpdateUsuario(),
                response.Code,
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new Result<UpdateUsuarioResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (UPDATE). Erro: {ex.Message}"
                );
        }
    }
}