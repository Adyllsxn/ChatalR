namespace Kairos.Presentation.Features.Sugestao.Controller;
[ApiController]
[Route("v1/")]
public class SugestaosController(ISugestaoService service) : ControllerBase
{
    #region </GetAll>
        [HttpGet("Sugestao"), EndpointSummary("Obter Sugestao")]
        public async Task<ActionResult> Get([FromQuery] GetSugestaoCommand command,CancellationToken token)
        {
            var response = await service.GetHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </GetReadAll>
        [HttpGet("ReadSugestao"), EndpointSummary("Obter sugestões lidas")]
        public async Task<ActionResult> GetRead([FromQuery] GetSugestaoCommand command,CancellationToken token)
        {
            var response = await service.GetAllReadHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </GetUnReadAll>
        [HttpGet("UnReadSugestao"), EndpointSummary("Obter sugestões não lidas")]
        public async Task<ActionResult> GetAllUnread([FromQuery] GetSugestaoCommand command,CancellationToken token)
        {
            var response = await service.GetAllUnreadHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </GetById>
        [HttpGet("SugestaoById"), EndpointSummary("Obter Sugestaõ Pelo Id")]
        public async Task<ActionResult> GetById([FromQuery] GetSugestaoByIdCommand command, CancellationToken token)
        {
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Create>
        [HttpPost("CreateSugestao"), EndpointSummary("Adicionar nova sugestão")]
        public async Task<IActionResult> Create(CreateSugestaoCommand command, CancellationToken token)
        {
            var response = await service.CreateHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Delete>
        [HttpDelete("DeleteSugestao"), EndpointSummary("Excluir Sugestão")]
        public async Task<ActionResult> Delete([FromQuery] DeleteSugestaoCommand command, CancellationToken token)
        {
            var response = await service.DeleteHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Update>
        [HttpPut("UpdateSugestao"), EndpointSummary("Editar Sugestão")]
        public async Task<ActionResult> Update(UpdateSugestaoCommand command, CancellationToken token)
        {
            var response = await service.UpdateHendler(command,token);
            return Ok(response);
        }
    #endregion

    #region </MarkAsRead>
        [HttpPatch("SugestaoLida"), EndpointSummary("Excluir Sugestão")]
        public async Task<ActionResult> MarkAsRead([FromQuery] MarkAsReadSugestaoCommand command, CancellationToken token)
        {
            var response = await service.MarkAsReadHandler(command,token);
            return Ok(response);
        }
    #endregion
}
