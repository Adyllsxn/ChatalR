namespace Kairos.Domain.Abstrations.Auth;
public interface IAuthIdentity
{
    Task<bool> AuthenticateAsync(string email, string senha);
    Task<bool> UserExistAsync(string email);
    public string GenerateTokenAsync(int id, string email);
    Task<UsuarioEntity?> GetUserByEmailAsync(string email);
}
