namespace Kairos.Presentation.Source.Features.Presenca;
[ApiController]
[Route("v1/")]
[Authorize]
public class PresencaController(IPresencaService service, IUsuarioService usuario) : ControllerBase
{
    #region ListPresenca
        [HttpGet("ListPresenca")]
        [EndpointSummary("Listar todas as presenças.")]
        public async Task<ActionResult> ListPresenca([FromQuery] GetPresencaCommand command,CancellationToken token)
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
            
            #region ListPresenca
                var response = await service.GetHandler(command,token);
                return Ok(response);
            #endregion
        }
    #endregion

    #region GetByIdPresenca
        [HttpGet("GetByIdPresenca")]
        [EndpointSummary("Obter presença pelo ID.")]
        public async Task<ActionResult> GetByIdPresenca([FromQuery] GetPresencaByIdCommand command, CancellationToken token)
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

            #region GetByIdPresenca
                var response = await service.GetByIdHandler(command,token);
                return Ok(response);
            #endregion
        }
    #endregion

    #region CreatePresenca
        [HttpPost("CreatePresenca")]
        [EndpointSummary("Registrar uma nova presença.")]
        public async Task<IActionResult> CreatePresenca(CreatePresencaCommand command, CancellationToken token)
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
            
            #region CreatePresenca
                var response = await service.CreateHandler(command,token);
                return Ok(response);
            #endregion
        }
    #endregion

    #region DeletePresenca
        [HttpDelete("DeletePresenca")]
        [EndpointSummary("Excluir presença pelo ID.")]
        public async Task<ActionResult> DeletePresenca([FromQuery] DeletePresencaCommand command, CancellationToken token)
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
            
            #region DeletePresenca
                var response = await service.DeleteHandler(command,token);
                return Ok(response);
            #endregion
        }
    #endregion
}

