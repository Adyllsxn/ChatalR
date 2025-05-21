namespace Kairos.Infrastructure.Abstractions.Identity;
public class AuthenticateIdentity : IAuthenticateIdentity
{
    public Task<bool> AuthenticateAsync(string email, string senha)
    {
        throw new NotImplementedException();
    }

    public string GenerateTokenAsync(int id, string email)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioEntity?> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserExistAsync(string email)
    {
        throw new NotImplementedException();
    }
}
