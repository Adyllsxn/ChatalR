namespace Kairos.Presentation.Source.Features.Dashboard;
[ApiController]
[Route("v1/")]
[Authorize]
public class DashboardController(IDashboardService service, IUsuarioService usuario) : ControllerBase
{
    #region Dashboard
        [HttpGet("GetDashboard")]
        [EndpointSummary("Retorna dados agregados do sistema para o painel do administrador.")]
        public async Task<ActionResult> GetDashboard(CancellationToken token)
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
            
            #region GetDashboard
                try
                {
                    var response = await service.GetHandler(token);
                    Logger.LogToFile(
                            "GetDashboard - Success", 
                            "Retorna dados agregados do sistema para o painel do administrador."
                        );
                        
                    return Ok(
                        $" PERFIL: {response.QtdPerfil} \n USUARIO: {response.QtdUsuario}  \n TIPO DE EVENTO: {response.QtdTipoEvento} \n EVENTO: {response.QtdEvento}\n PRESENCA: {response.QtdPresenca} \n BLOG POST: {response.QtdBlog} "
                    );
                }
                catch(Exception error)
                {
                    Logger.LogToFile(
                            "GetDashboard - Success", 
                            $"Error {error.Message}"
                        );
                    return Problem($"Error: {error.Message}");
                }
            #endregion
        }
    #endregion
}

