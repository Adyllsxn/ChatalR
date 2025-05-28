namespace Kairos.Presentation.Features.Perfil.Controller;
[ApiController]
[Route("v1/")]
[Authorize]
public class PerfilsController(IPerfilService service, IUsuarioService usuario) : ControllerBase
{
    #region </GetAll>
        [HttpGet("Perfils"), EndpointSummary("Obter Perfis")]
        public async Task<ActionResult> Get(CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1 || user.Data?.PerfilID == 2))
            {
                return Unauthorized("Você não tem permissão para visualizar perfis.");
            }

            var response = await service.GetHandler(token);
            return Ok(response);
        }
    #endregion

    #region </GetById>
        [HttpGet("TPerfilById"), EndpointSummary("Obter Perfil Pelo Id")]
        public async Task<ActionResult> GetById([FromQuery] GetPerfilByIdCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1 || user.Data?.PerfilID == 2))
            {
                return Unauthorized("Você não tem permissão para visualizar perfil.");
            }

            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Search>
        [HttpGet("SearchPerfil"), EndpointSummary("Pesquisar Perfil")]
        public async Task<ActionResult> Search([FromQuery] SearchPerfilCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1 || user.Data?.PerfilID == 2))
            {
                return Unauthorized("Você não tem permissão para visualizar perfil.");
            }

            var response = await service.SearchHendler(command,token);
            return Ok(response);
        }
    #endregion
}
