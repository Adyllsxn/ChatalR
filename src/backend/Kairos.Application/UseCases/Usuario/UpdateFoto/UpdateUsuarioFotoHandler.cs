namespace Kairos.Application.UseCases.Usuario.UpdateFoto;
public class UpdateUsuarioFotoHandler(IUsuarioRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> UpdateFotoHandler(UpdateUsuarioFotoCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);

            if (resultEntity == null || resultEntity.Data == null)
            {
                return CommandResult<bool>.Failure(
                    value: false,
                    message: $"Usuario {command.Id} não encontrado.",
                    code: StatusCode.NoContent
                    );
            }

            var entity = resultEntity.Data;
            entity.UpdateFoto(command.Id,command.FotoUrl);

            await unitOfWork.CommitAsync(token);
            return CommandResult<bool>.Success(
                value: true,
                message: "Foto atualizado com sucesso.",
                code: StatusCode.NoContent
                );
        }
        catch (Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (EDITAR FOTO). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
                );
        }
    }
}
