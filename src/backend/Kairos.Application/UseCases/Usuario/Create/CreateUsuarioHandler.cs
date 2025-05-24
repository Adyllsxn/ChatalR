namespace Kairos.Application.UseCases.Usuario.Create;
public class CreateUsuarioHandler(IUsuarioRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<CreateUsuarioResponse>> CreateHandler(CreateUsuarioCommand command, CancellationToken token)
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
            await unitOfWork.CommitAsync();

            return new Result<CreateUsuarioResponse>(
                response.Data?.MapToCreateUsuario(), 
                response.Code, 
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new Result<CreateUsuarioResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (CRIAR). Erro: {ex.Message}"
                );
        }
    }
}