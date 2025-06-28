namespace Kairos.Application.UseCases.Usuario.Update;
public class UpdateUsuarioHandler(IUsuarioRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> UpdateHandler(UpdateUsuarioCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);

            if (resultEntity == null || resultEntity.Data == null)
            {
                return CommandResult<bool>.Failure(
                    value: false,
                    message: $"Evento não encontrado.",
                    code: StatusCode.NotFound
                    );
            }

            var entity = resultEntity.Data;

            entity.UpdateInfo(command.Id,command.Nome, command.SobreNome,command.Email,command.DataCadastro,command.Telefone,command.BI);

            await unitOfWork.CommitAsync(token);
            //var response = entity.MapToUpdateUsuarioResponse(); 
            return CommandResult<bool>.Success(
                value: true,
                message: "Operação executada com sucesso",
                code: StatusCode.NoContent
                );
        }
        catch (Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (EDITAR). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
                );
        }
    }
}
