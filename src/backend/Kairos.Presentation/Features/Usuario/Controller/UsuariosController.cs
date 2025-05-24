namespace Kairos.Presentation.Features.Usuario.Controller;
[ApiController]
[Route("v1/")]
public class UsuariosController(IUsuarioService service, IAuthenticateIdentity authentication)  : ControllerBase
{

    #region </Register>
        [HttpPost("Register"), EndpointSummary("Registrar um novo usuário.")]
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
        [HttpPost("Login"), EndpointSummary("Fazendo o login no sistema")]
        public async Task<ActionResult<TokenModel>> Login(LoginModel login)
        {
            var emailExist = await authentication.UserExistAsync(login.Email);
            if(!emailExist)
            {
                return Unauthorized("Usuário não existe");
            }
            
            var result = authentication.AuthenticateAsync(login.Email, login.Password);
            if(result == null)
            {
                return Unauthorized("Usuário ou Senha Inválida.");
            }

            var usuario = await authentication.GetUserByEmailAsync(login.Email);
            if (usuario == null)
            {
                return Unauthorized("Usuário não encontrado.");
            }

            var createToken = authentication.GenerateTokenAsync(usuario.Id, usuario.Email);

            return new TokenModel{
                Token = createToken,
                Nome = usuario.Nome,
                SobreNome = usuario.SobreNome,
                Email = usuario.Email
            };
        }
    #endregion

    #region </GetAll>
        [HttpGet("Usuarios"), EndpointSummary("Obter Usuarios")]
        [Authorize]
        public async Task<ActionResult> Get([FromQuery] GetUsuariosCommand command,CancellationToken token)
        {
            var userId = User.GetId();
            var user = await service.GetByIdHandler(new GetUsuarioByIdCommand{Id = userId}, token);
            if(!(user.Data?.PerfilID == 1))
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema");
            }

            var response = await service.GetHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </GetById>
        [HttpGet("UsuarioById"), EndpointSummary("Obter Usuario Pelo Id")]
        [Authorize]
        public async Task<ActionResult> GetById([FromQuery] GetUsuarioByIdCommand command, CancellationToken token)
        {
            var userId = User.GetId();
            var user = await service.GetByIdHandler(new GetUsuarioByIdCommand{Id = userId}, token);
            if(command.Id == 0)
            {
                command.Id = userId;
            }
            bool isAdmin = user.Data?.PerfilID == 1;
            bool consultandoProprioUsuario = user.Data?.Id == command.Id;

            if (!consultandoProprioUsuario && !isAdmin)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Search>
        [HttpGet("SearchUsuario"), EndpointSummary("Pesquisar Usuarios")]
        [Authorize]
        public async Task<ActionResult> Search([FromQuery] SearchUsuarioCommand command, CancellationToken token)
        {
            var response = await service.SearchHendler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Delete>
        [HttpDelete("DeleteUsuario"), EndpointSummary("Excluir Usuario")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeleteUsuarioCommand command, CancellationToken token)
        {
            var userId = User.GetId();
            var user = await service.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if (!(user.Data?.PerfilID == 1))
            {
                return Unauthorized("Você não tem permissão para deletar os usuários do sistema");
            }

            var response = await service.DeleteHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Update>
        [HttpPut("UpdateUsuario"), EndpointSummary("Editar o usuário.")]
        [Authorize]
        [Authorize]
        public async Task<ActionResult> UpdateAsync(UpdateUsuarioCommand command, CancellationToken token)
        {
            try
            {
                var userId = User.GetId();
                var user = await service.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
                if (!(user.Data?.PerfilID == 1 && command.Id != userId))
                {
                    return Unauthorized("Você não tem permissão para alterar os usuários do sistema");
                }
                if (!(user.Data?.PerfilID == 1 && command.Id == userId && command.PerfilID == 1))
                {
                        return Unauthorized("Você não tem permissão para definir você mesmo com administardor");
                }

                var usuario = await service.UpdateHendler(command, token);
                if (usuario == null)
                {
                    return BadRequest("Ocorreu um erro ao alterar o usuário!");
                }
                return Ok("Usuário alterado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    #endregion

}
