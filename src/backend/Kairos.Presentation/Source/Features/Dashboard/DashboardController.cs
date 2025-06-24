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
            try
            {
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }

                var userId = User.GetId();
                var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
                if(!(user.Data?.PerfilID == PerfilConstant.Adm))
                {
                    return Unauthorized("Reservado apenas para adm.");
                }

                Log.LogToFile("GetDashboard - Success", "Retorna dados agregados do sistema para o painel do administrador.");

                var response = await service.GetHandler(token);
                return Ok(
                    $" PERFIL: {response.QtdPerfil} \n USUARIO: {response.QtdUsuario}  \n TIPO DE EVENTO: {response.QtdTipoEvento} \n EVENTO: {response.QtdEvento}\n PRESENCA: {response.QtdPresenca} \n BLOG POST: {response.QtdBlog} "
                );
            }
            catch(Exception error)
            {
                Problem($"Error: {error.Message}");
                Log.LogToFile("GetDashboard - Success", $"Error {error.Message}");
                return null!;
            }
        }
    #endregion
}

