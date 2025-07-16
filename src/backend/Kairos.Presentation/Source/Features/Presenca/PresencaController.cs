namespace Kairos.Presentation.Source.Features.Presenca;
[ApiController]
[Route("v1/")]
[Authorize]
public class PresencaController(IPresencaService service) : ControllerBase
{
    #region ListPresenca
        [HttpGet("ListPresenca")]
        [EndpointSummary("Listar todas as presenças.")]
        public async Task<ActionResult> ListPresenca([FromQuery] GetPresencaCommand command,CancellationToken token)
        {
            #region Authorize
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }
            #endregion
            
            #region ListPresenca
                var response = await service.GetHandler(command,token);
                return Ok(response);
            #endregion
        }
    #endregion

    #region GetByIdPresenca
        [HttpGet("GetByIdPresenca")]
        [EndpointSummary("Obter presença pelo ID.")]
        public async Task<ActionResult> GetByIdPresenca([FromQuery] GetPresencaByIdCommand command, CancellationToken token)
        {
            #region Authorize
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }
                var userId = User.GetId();
                var newCommand = new GetPresencaByIdCommand{
                    Id = userId
                };
            #endregion

            #region GetByIdPresenca
                var response = await service.GetByIdHandler(newCommand,token);
                return Ok(response);
            #endregion
        }
    #endregion

    #region SearchPresenca
        [HttpGet("SearchPresenca")]
        [EndpointSummary("Pesquisar presença por filtros do usuário.")]
        public async Task<ActionResult> SearchPresenca([FromQuery] SearchPresencaCommand command, CancellationToken token)
        {
            #region Authorize
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }
                var userId = User.GetId();
            #endregion

            #region SearchEvento
                try
                {
                    
                    var newCommand = new SearchPresencaCommand{
                        UsuarioID = userId
                    };

                    var response = await service.SearchHendler(newCommand,token);
                    return Ok(response);
                }
                catch(Exception error)
                {
                    return Problem($"Error: {error.Message}");
                }
            #endregion
        }
    #endregion


    #region CreatePresenca
        [HttpPost("CreatePresenca")]
        [EndpointSummary("Registrar uma nova presença.")]
        public async Task<IActionResult> CreatePresenca(CreatePresencaCommand command, CancellationToken token)
        {
            #region Authorize
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }
                var userId = User.GetId();
                var newCommand = new CreatePresencaCommand{
                    UsuarioID = userId,
                    EventoID = command.EventoID,
                    Confirmado = command.Confirmado
                };
            #endregion
            
            #region CreatePresenca
                var response = await service.CreateHandler(newCommand,token);
                return Ok(response);
            #endregion
        }
    #endregion

    #region DeletePresenca
        [HttpDelete("DeletePresenca")]
        [EndpointSummary("Excluir presença pelo ID.")]
        public async Task<ActionResult> DeletePresenca([FromQuery] DeletePresencaCommand command, CancellationToken token)
        {
            #region Authorize
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }
                var userId = User.GetId();
                var newCommand = new DeletePresencaCommand{
                    Id = command.Id,
                    UsuarioID = userId,
                };
            #endregion
            
            #region DeletePresenca
                var response = await service.DeleteHandler(newCommand,token);
                return Ok(response);
            #endregion
        }
    #endregion

}

