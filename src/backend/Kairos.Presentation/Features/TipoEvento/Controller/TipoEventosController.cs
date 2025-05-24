namespace Kairos.Presentation.Features.TipoEvento.Controller;
[ApiController]
[Route("v1/")]
[Authorize]
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

    #region </GetById>
        [HttpGet("TipoEventoById"), EndpointSummary("Obter Tipo de Evento Pelo Id")]
        public async Task<ActionResult> GetById([FromQuery] GetTipoEventoByIdCommand command, CancellationToken token)
        {
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Search>
        [HttpGet("SearchTipoEvento"), EndpointSummary("Pesquisar Tipo de Eventos")]
        public async Task<ActionResult> Search([FromQuery] SearchTipoEventoCommand command, CancellationToken token)
        {
            var response = await service.SearchHendler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Create>
        [HttpPost("CreateTipoEvento"), EndpointSummary("Adicionar Tipo de Evento")]
        public async Task<IActionResult> Create(CreateTipoEventoCommand command, CancellationToken token)
        {
            var response = await service.CreateHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Delete>
        [HttpDelete("DeleteTipoEvento"), EndpointSummary("Excluir Tipo de Evento")]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeleteTipoEventoCommand command, CancellationToken token)
        {
            var response = await service.DeleteHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Update>
        [HttpPut("UpdateTipoEvento"), EndpointSummary("Editar Tipo de Evento")]
        public async Task<ActionResult> Update(UpdateTipoEventoCommand command, CancellationToken token)
        {
            var response = await service.UpdateHendler(command,token);
            return Ok(response);
        }
    #endregion

}
