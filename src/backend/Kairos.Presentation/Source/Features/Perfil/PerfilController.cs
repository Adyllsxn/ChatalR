namespace Kairos.Presentation.Source.Features.Perfil;
[ApiController]
[Route("v1/")]
[Authorize]
public class PerfilController(IPerfilService service, IUsuarioService usuario) : ControllerBase
{
    #region ListPerfil
        [HttpGet("ListPerfil")]
        [EndpointSummary("Listar todos os perfis.")]
        public async Task<ActionResult> ListPerfil(CancellationToken token)
        {
            #region Authorize
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }
                var userId = User.GetId();
                var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
                if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
                {
                    return Unauthorized("Você não tem permissão para Visualizar a Dashboard.");
                }
            #endregion

            #region ListPerfil
                try
                {
                    var response = await service.GetHandler(token);
                    return Ok(response);
                }
                catch(Exception error)
                {
                    return Problem($"Error: {error.Message}");
                }
            #endregion
        }
    #endregion

    #region GetByIdPerfil
        [HttpGet("GetByIdPerfil")]
        [EndpointSummary("Obter perfil pelo ID.")]
        public async Task<ActionResult> GetByIdPerfil([FromQuery] GetPerfilByIdCommand command, CancellationToken token)
        {
            #region Authorize
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }
                var userId = User.GetId();
                var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
                if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
                {
                    return Unauthorized("Você não tem permissão para Visualizar a Dashboard.");
                }
            #endregion

            #region GetByIdPerfil
                try
                {
                    var response = await service.GetByIdHandler(command,token);
                    return Ok(response);
                }
                catch(Exception error)
                {
                    return Problem($"Error: {error.Message}");
                }
            #endregion
        }
    #endregion

    #region SearchPerfil
        [HttpGet("SearchPerfil")]
        [EndpointSummary("Pesquisar perfil por filtros.")]
        public async Task<ActionResult> Search([FromQuery] SearchPerfilCommand command, CancellationToken token)
        {
            #region Authorize
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }
                var userId = User.GetId();
                var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
                if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
                {
                    return Unauthorized("Você não tem permissão para Visualizar a Dashboard.");
                }
            #endregion

            #region Search
                try
                {
                    var response = await service.SearchHendler(command,token);
                    return Ok(response);
                }
                catch(Exception error)
                {
                    return Problem($"Error: {error.Message}");
                }
            #endregion
        }
    #endregion
}

