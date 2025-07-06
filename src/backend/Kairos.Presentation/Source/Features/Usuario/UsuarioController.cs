namespace Kairos.Presentation.Source.Features.Usuario;
[ApiController]
[Route("v1/")]
[Authorize]
public class UsuarioController(IUsuarioService service)  : ControllerBase
{
    #region ListUsuario
        [HttpGet("ListUsuario")]
        [EndpointSummary("Listar todos os usuários.")]
        [Authorize]
        public async Task<ActionResult> ListUsuario([FromQuery] GetUsuariosCommand command,CancellationToken token)
        {
            var userId = User.GetId();
            var user = await service.GetByIdHandler(new GetUsuarioByIdCommand{Id = userId}, token);
            if(!(user.Data?.PerfilID == PerfilConstant.Adm))
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema");
            }

            var response = await service.GetHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region GetByIdUsuario
        [HttpGet("GetByIdUsuario")]
        [EndpointSummary("Obter usuário pelo ID.")]
        [Authorize]
        public async Task<ActionResult> GetById([FromQuery] GetUsuarioByIdCommand command, CancellationToken token)
        {
            var userId = User.GetId();
            var user = await service.GetByIdHandler(new GetUsuarioByIdCommand{Id = userId}, token);
            if(command.Id == 0)
            {
                command.Id = userId;
            }
            bool isAdmin = user.Data?.PerfilID == PerfilConstant.Adm;
            bool consultandoProprioUsuario = user.Data?.Id == command.Id;

            if (!consultandoProprioUsuario && !isAdmin)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion
    
    #region GetCurrentUsuario
        [HttpGet("GetCurrentUsuario")]
        [EndpointSummary("Obter dados do usuário autenticado.")]
        [Authorize]
        public async Task<ActionResult> GetCurrentUsuario()
        {
            var command = new GetUsuarioByIdCommand();
            var token = new CancellationToken();
            
            var userId = User.GetId();
            var user = await service.GetByIdHandler(new GetUsuarioByIdCommand{Id = userId}, token);
            if(command?.Id == 0)
            {
                command.Id = userId;
            }
            bool isAdmin = user.Data?.PerfilID == 1;
            bool consultandoProprioUsuario = user.Data?.Id == command?.Id;

            if (!consultandoProprioUsuario && !isAdmin)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }

            var newCommand = new GetUsuarioByIdCommand{
                Id = userId
            };
            var response = await service.GetByIdHandler(newCommand,token);
            return Ok(response);
        }
    #endregion

    #region GetFotoUsuario
        [HttpGet("GetFotoUsuario")]
        [EndpointSummary("Obter a foto do usuário pelo ID.")]
        public async Task<ActionResult> GetFotoUsuario([FromQuery] GetUsuarioFotoCommand command, CancellationToken token)
        {
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }

                var userId = User.GetId();

                var response = await service.GetFotoHandler(command,token);
                if(response.Data?.FotoUrl == null)
                {
                    return BadRequest("Imagem não encontrada");
                }
                var databyte = System.IO.File.ReadAllBytes(response.Data.FotoUrl);
                return File(databyte, "image/jpg");
        }
    #endregion

    #region SearchUsuario
        [HttpGet("SearchUsuario")]
        [EndpointSummary("Pesquisar usuários.")]
        [Authorize]
        public async Task<ActionResult> SearchUsuario([FromQuery] SearchUsuarioCommand command, CancellationToken token)
        {
            var response = await service.SearchHendler(command,token);
            return Ok(response);
        }
    #endregion

    #region UpdateUsuario
        [HttpPut("UpdateUsuario")]
        [EndpointSummary("Atualizar usuário.")]
        public async Task<ActionResult> UpdateUsuario(UpdateUsuarioCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var response = await service.UpdateHandler(command,token);
            return Ok(response);
        }
    #endregion
    
    #region UpdatePerfilUsuario
        [HttpPatch("UpdatePerfilUsuario")]
        [EndpointSummary("Atualizar o perfil do usuário.")]
        public async Task<ActionResult> UpdatePerfilUsuario(UsuarioStatusCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var response = await service.StatusHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region UpdateFotoUsuario
        [HttpPatch("UpdateFotoUsuario")]
        [EndpointSummary("Atualizar a foto do usuário.")]
        public async Task<ActionResult> UpdateFotoUsuario([FromForm] UsuarioUpdateFotoModel model, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var getCommand = new GetUsuarioByIdCommand { Id = model.Id };
            var result = await service.GetByIdHandler(getCommand, token);

            if (result.Data is null)
                return NotFound("Postagem não encontrada.");

            string caminhoAntigo = result.Data.FotoUrl;
            string caminhoNovo = caminhoAntigo;

            if (model.FotoUrl != null && model.FotoUrl.Length > 0)
            {
                var extensao = Path.GetExtension(model.FotoUrl.FileName).ToLower();
                var extensoesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!extensoesPermitidas.Contains(extensao))
                    return BadRequest("Extensão de imagem inválida. Use JPG, JPEG, PNG ou GIF.");

                string pasta = Path.Combine("Storage", "Images");
                Directory.CreateDirectory(pasta);

                string novoNome = $"{Guid.NewGuid()}{extensao}";
                caminhoNovo = Path.Combine(pasta, novoNome);

                await using var stream = new FileStream(caminhoNovo, FileMode.Create);
                await model.FotoUrl.CopyToAsync(stream);
            }

            var command = new UpdateUsuarioFotoCommand
            {
                Id = model.Id,
                FotoUrl = caminhoNovo
            };

            var response = await service.UpdateFotoHandler(command, token);
            return Ok(response);
        }
    #endregion

    #region DeleteUsuario
        [HttpDelete("DeleteUsuario")]
        [EndpointSummary("Excluir usuário.")]
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
}
