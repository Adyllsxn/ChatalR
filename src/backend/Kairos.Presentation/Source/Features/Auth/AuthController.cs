namespace Kairos.Presentation.Source.Features.Auth;
[ApiController]
[Route("v1/")]
public class AuthController(IUsuarioService service, IAuthenticateIdentity authentication) : ControllerBase
{
    #region Register
        [HttpPost("Register")]
        [EndpointSummary("Registrar um novo usuário no sistema.")]
        public async Task<ActionResult<TokenModel>> Register(CreateUsuarioCommand command, CancellationToken token)
        {
            var emailExist = await authentication.UserExistAsync(command.Email);
            if(emailExist)
            {
                return BadRequest("Este email já possui um cadastro.");
            }

            var existeUsuarioSistema = await service.GetIfExistHandle();
            if(!existeUsuarioSistema)
            {
                command.PerfilID = 1;
            }
            else
            {
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }

                var userId = User.GetId();
                var user = await service.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
                if(!(user.Data?.PerfilID == 1))
                {
                    return Unauthorized("Você não tem permissão para incluir novo usuário.");
                }
            }

            var response = await service.CreateHandler(command,token);
            if(response == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar.");
            }

            var tokenReturn = authentication.GenerateTokenAsync(command.Id, command.Email);
            return new TokenModel{
                Token = tokenReturn,
                Nome = command.Nome,
                SobreNome = command.SobreNome,
                Email = command.Email
            };
        }
    #endregion

    #region </Login>
        [HttpPost("Login")]
        [EndpointSummary("Fazer login no sistema e gerar token JWT.")]
        public async Task<ActionResult<TokenModel>> Login(AuthModel login)
        {
            // Verifica se o usuário existe
            var usuario = await authentication.GetUserByEmailAsync(login.Email);
            if (usuario == null)
            {
                return Unauthorized("Usuário não existe.");
            }

            // Verifica a senha
            var autenticado = await authentication.AuthenticateAsync(login.Email, login.Password);
            if (!autenticado)
            {
                return Unauthorized("Usuário ou senha inválida.");
            }

            // Gera o token
            var token = authentication.GenerateTokenAsync(usuario.Id, usuario.Email);

            return new TokenModel
            {
                Token = token,
                Nome = usuario.Nome,
                SobreNome = usuario.SobreNome,
                Email = usuario.Email,
                PerfilID = usuario.PerfilID
            };
        }

    #endregion

}

