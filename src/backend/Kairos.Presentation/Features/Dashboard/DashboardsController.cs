namespace Kairos.Presentation.Features.Dashboard;
[ApiController]
[Route("api/")]
[Authorize]
public class DashboardsController(IDashboardService service, IUsuarioService usuario) : ControllerBase
{
    #region </Dashboard>
        [HttpGet("Dashboard"), EndpointSummary("Painel de todas entidades.")]
        public async Task<ActionResult> Dashboard(CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1))
            {
                return Unauthorized("Reservado apenas para adm.");
            }

            var response = await service.GetHandler(token);
            return Ok(
                $" PERFIL: {response.QtdPerfil} \n USUARIO: {response.QtdUsuario}  \n TIPO DE EVENTO: {response.QtdTipoEvento} \n EVENTO: {response.QtdEvento}\n PRESENCA: {response.QtdPresenca} \n SUGESTAO: {response.QtdSugestao} "
            );
        }
    #endregion
}
