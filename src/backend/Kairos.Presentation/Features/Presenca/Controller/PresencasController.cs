namespace Kairos.Presentation.Features.Presenca.Controller;
[ApiController]
[Route("v1/")]
public class PresencasController(IPresencaService service) : ControllerBase
{
    #region ListPresenca
        [HttpGet("ListPresenca")]
        [EndpointSummary("Listar todas as presenças.")]
        public async Task<ActionResult> ListPresenca([FromQuery] GetPresencaCommand command,CancellationToken token)
        {
            var response = await service.GetHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region GetByIdPresenca
        [HttpGet("GetByIdPresenca")]
        [EndpointSummary("Obter presença pelo ID.")]
        public async Task<ActionResult> GetByIdPresenca([FromQuery] GetPresencaByIdCommand command, CancellationToken token)
        {
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region CreatePresenca
        [HttpPost("CreatePresenca")]
        [EndpointSummary("Registrar uma nova presença.")]
        public async Task<IActionResult> CreatePresenca(CreatePresencaCommand command, CancellationToken token)
        {
            var response = await service.CreateHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region DeletePresenca
        [HttpDelete("DeletePresenca")]
        [EndpointSummary("Excluir presença pelo ID.")]
        public async Task<ActionResult> DeletePresenca([FromQuery] DeletePresencaCommand command, CancellationToken token)
        {
            var response = await service.DeleteHandler(command,token);
            return Ok(response);
        }
    #endregion
}
