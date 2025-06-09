namespace Kairos.Application.UseCases.Usuario.Update;
public class UpdateUsuarioHandler(IUsuarioRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<UpdateUsuarioResponse>> UpdateHandler(UpdateUsuarioCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);

            if (resultEntity == null || resultEntity.Data == null)
                return new Result<UpdateUsuarioResponse>(null, 404, "Evento não encontrado.");

            var entity = resultEntity.Data;

            entity.UpdateInfo(command.Id,command.Nome, command.SobreNome,command.Email,command.DataCadastro,command.Telefone,command.BI);

            await unitOfWork.CommitAsync();

            var response = entity.MapToUpdateUsuarioResponse(); 

            return new Result<UpdateUsuarioResponse>(response, 200, "Status atualizado com sucesso.");
        }
        catch (DomainValidationException ex)
        {
            // captura erro de domínio e devolve como resultado
            return new Result<UpdateUsuarioResponse>(null, 400, ex.Message);
        }
        catch (Exception ex)
        {
            return new Result<UpdateUsuarioResponse>(null, 500, $"Erro ao atualizar status: {ex.Message}");
        }
    }
}
