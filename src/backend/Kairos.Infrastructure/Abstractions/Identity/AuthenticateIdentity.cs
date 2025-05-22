namespace Kairos.Infrastructure.Abstractions.Identity;
public class AuthenticateIdentity(AppDbContext context, IConfiguration configuration) : IAuthenticateIdentity
{
    #region </Authentication>
        public async Task<bool> AuthenticateAsync(string email, string senha)
        {
            try
            {
                var usuario = await context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
                if(usuario == null)
                {
                    return false;
                }
                
                using   var hmac = new HMACSHA512(usuario.PasswordSalt);
                        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
                        for(int x = 0; x < computedHash.Length; x++)
                        {
                            if(computedHash[x] != usuario.PasswordHash[x])
                                return false;
                        }
                return true;

            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    #endregion
    
    #region </GenerateToken>
        public string GenerateTokenAsync(int id, string email)
        {
            try
            {
                var claims = new[]
                {
                    new Claim("id", id.ToString()),
                    new Claim("email", email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:secretKey"] ?? throw new InvalidOperationException("JWT secret key is not configured.")));
                var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
                var expiration =  DateTime.UtcNow.AddMinutes(10);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: configuration["jwt:issuer"],
                    audience: configuration["jwt:audience"],
                    claims: claims,
                    expires: expiration,
                    signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    #endregion

    #region </GetByEmail>
        public async Task<UsuarioEntity?> GetUserByEmailAsync(string email)
        {
            try
            {
                return await context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    #endregion

    #region </Exist>
        public async Task<bool> UserExistAsync(string email)
        {
            try
                {
                    var usuario = await context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
                    if(usuario == null)
                    {
                        return false;
                    }
                    return true;
                }
                catch(Exception error)
                {
                    throw new Exception(error.Message);
                }
        }
    #endregion
}
