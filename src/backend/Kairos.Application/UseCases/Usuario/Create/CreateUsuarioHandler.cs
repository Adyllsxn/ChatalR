namespace Kairos.Application.UseCases.Usuario.Create;
public class CreateUsuarioHandler(IUsuarioRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> CreateHandler(CreateUsuarioCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToUsuarioEntity();

            if(command.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(command.Password));
                byte[] passwordSalt = hmac.Key;

                entity.UpdatePassword(passwordHash, passwordSalt);
            }

            var response = await repository.CreateAsync(entity, token);
            await unitOfWork.CommitAsync(token);
            return CommandResult<bool>.Success(
                value: true,
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (CRIAR). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
                );
        }
    }
}