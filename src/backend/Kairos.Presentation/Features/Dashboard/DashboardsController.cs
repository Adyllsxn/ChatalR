namespace Kairos.Presentation.Features.Dashboard;
[ApiController]
[Route("api/")]
public class DashboardsController(IDashboardService service) : ControllerBase
{
    #region </Dashboard>
        [HttpGet("Dashboard"), EndpointSummary("Painel de todas entidades.")]
        public async Task<ActionResult> Dashboard(CancellationToken token)
        {
            var response = await service.GetHandler(token);
            return Ok(
                $" CATEGORIA: {response.QtdPerfil} \n PERFIL: {response.QtdTipoEvento} \n TIPO EVENTO: {response.QtdTipoEvento} \n TIPO USUÁRIO: {response.QtdUsuario} \n EVENTO: {response.QtdEvento} \n PRESENÇA: {response.QtdPresenca} \n SUGESTÃO: {response.QtdSugestao} "
            );
        }
    #endregion
}
