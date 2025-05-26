namespace Kairos.Presentation.Features.Presenca.Controller;
[ApiController]
[Route("v1/")]
public class PresencasController(IPresencaService service) : ControllerBase
{
    #region </GetAll>
        [HttpGet("Presencas"), EndpointSummary("Obter Presencas")]
        public async Task<ActionResult> Get([FromQuery] GetPresencaCommand command,CancellationToken token)
        {
            var response = await service.GetHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </GetById>
        [HttpGet("PresencaById"), EndpointSummary("Obter Presenca Pelo Id")]
        public async Task<ActionResult> GetById([FromQuery] GetPresencaByIdCommand command, CancellationToken token)
        {
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Create>
        [HttpPost("CreatePresenca"), EndpointSummary("Adicionar Presenca")]
        public async Task<IActionResult> Create(CreatePresencaCommand command, CancellationToken token)
        {
            var response = await service.CreateHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Delete>
        [HttpDelete("DeletePresnca"), EndpointSummary("Excluir Presenca")]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeletePresencaCommand command, CancellationToken token)
        {
            var response = await service.DeleteHandler(command,token);
            return Ok(response);
        }
    #endregion
}
