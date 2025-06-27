namespace Kairos.Presentation.Source.Features.TipoEvento;
[ApiController]
[Route("v1/")]
public class TipoEventoController(ITipoEventoService service, IUsuarioService usuario) : ControllerBase
{
    #region ListTipoEvento
        [HttpGet("ListTipoEvento")]
        [EndpointSummary("Listar todos os tipos de evento.")]
        public async Task<ActionResult> ListTipoEvento([FromQuery] GetTipoEventosCommand command,CancellationToken token)
        {
            var response = await service.GetHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region GetByIdTipoEvento
        [HttpGet("GetByIdTipoEvento")]
        [EndpointSummary("Obter tipo de evento pelo ID.")]
        public async Task<ActionResult> GetByIdTipoEvento([FromQuery] GetTipoEventoByIdCommand command, CancellationToken token)
        {
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region SearchTipoEvento
        [HttpGet("SearchTipoEvento")]
        [EndpointSummary("Pesquisar tipos de evento.")]
        public async Task<ActionResult> Search([FromQuery] SearchTipoEventoCommand command, CancellationToken token)
        {
            var response = await service.SearchHendler(command,token);
            return Ok(response);
        }
    #endregion

    #region CreateTipoEvento
        [HttpPost("CreateTipoEvento")]
        [EndpointSummary("Criar um novo tipo de evento.")]
        public async Task<IActionResult> CreateTipoEvento(CreateTipoEventoCommand command, CancellationToken token)
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

    #region UpdateTipoEvento
        [HttpPut("UpdateTipoEvento")]
        [EndpointSummary("Atualizar um tipo de evento.")]
        public async Task<ActionResult> UpdateTipoEvento(UpdateTipoEventoCommand command, CancellationToken token)
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

    #region DeleteTipoEvento
        [HttpDelete("DeleteTipoEvento")]
        [EndpointSummary("Excluir um tipo de evento.")]
        public async Task<ActionResult> DeleteTipoEvento([FromQuery] DeleteTipoEventoCommand command, CancellationToken token)
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
}
