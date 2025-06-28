namespace Kairos.Application.UseCases.Usuario.Status;
public class UsuarioStatusHandler(IUsuarioRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> StatusHandler(UsuarioStatusCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);

            if (resultEntity == null || resultEntity.Data == null)
            {
                return CommandResult<bool>.Success(
                    value: true,
                    message: $"Usuário {command.Id} não encontrado.",
                    code: StatusCode.NoContent
                    );
            }

            var entity = resultEntity.Data;
            entity.UpdatePerfil(command.Perfil.Id);
            await unitOfWork.CommitAsync(token);

            var response = entity.MapToUsuarioStatusResponse(); 
            return CommandResult<bool>.Success(
                value: true,
                message: "Status atualizado com sucesso.",
                code: StatusCode.NoContent
                );
        }
        catch (Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (EDITAR PERFIL). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
                );
        }
    }

}
