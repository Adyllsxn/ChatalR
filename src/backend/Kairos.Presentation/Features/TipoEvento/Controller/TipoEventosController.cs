namespace Kairos.Presentation.Features.TipoEvento.Controller;
[ApiController]
[Route("v1/")]
[Authorize]
public class TipoEventosController(ITipoEventoService service, IUsuarioService usuario) : ControllerBase
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
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1 || user.Data?.PerfilID == 2))
            {
                return Unauthorized("Você não tem permissão para criar tipo de evento.");
            }

            var response = await service.CreateHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Delete>
        [HttpDelete("DeleteTipoEvento"), EndpointSummary("Excluir Tipo de Evento")]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeleteTipoEventoCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1 || user.Data?.PerfilID == 2))
            {
                return Unauthorized("Você não tem permissão para deletar tipo de evento.");
            }
            var response = await service.DeleteHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Update>
        [HttpPut("UpdateTipoEvento"), EndpointSummary("Editar Tipo de Evento")]
        public async Task<ActionResult> Update(UpdateTipoEventoCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1 || user.Data?.PerfilID == 2))
            {
                return Unauthorized("Você não tem permissão para atualizar tipo de evento.");
            }

            var response = await service.UpdateHendler(command,token);
            return Ok(response);
        }
    #endregion

}
