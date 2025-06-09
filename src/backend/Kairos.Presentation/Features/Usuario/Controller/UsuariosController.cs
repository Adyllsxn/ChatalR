using Kairos.Application.UseCases.Usuario.Status;
using Kairos.Application.UseCases.Usuario.Update;

namespace Kairos.Presentation.Features.Usuario.Controller;
[ApiController]
[Route("v1/")]
public class UsuariosController(IUsuarioService service)  : ControllerBase
{

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
    
    #region </GetNotId>
        [HttpGet("UsuarioGetNotId"), EndpointSummary("Obter Usuario Sem o  Id")]
        [Authorize]
        public async Task<ActionResult> GetGetNotId()
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

    /* #region </Update>
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
    #endregion */
    #region </Update>
        [HttpPut("UpdateUsuario"), EndpointSummary("Atualizar Usuário")]
        public async Task<ActionResult> Update(UpdateUsuarioCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var response = await service.UpdateHandler(command,token);
            return Ok(response);
        }
    #endregion
    
    #region </Status>
        [HttpPatch("UpdatePerfilUsuario"), EndpointSummary("Atualizar o Perfil do Usuário")]
        public async Task<ActionResult> Update(UsuarioStatusCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var response = await service.StatusHandler(command,token);
            return Ok(response);
        }
    #endregion

}
