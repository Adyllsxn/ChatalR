namespace Kairos.Presentation.Features.TipoEvento.Controller;
[ApiController]
[Route("v1/")]
public class TipoEventosController(ITipoEventoService service) : ControllerBase
{
    #region </GetAll>
        [HttpGet("TipoEventos"), EndpointSummary("Obter Tipo de Eventos")]
        public async Task<ActionResult> Get([FromQuery] GetTipoEventosCommand command,CancellationToken token)
        {
            var response = await service.GetHandler(command,token);
            return Ok(response);
        }
    #endregion
}
