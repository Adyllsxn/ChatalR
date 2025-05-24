namespace Kairos.Presentation.Features.Perfil.Controller;
[ApiController]
[Route("v1/")]
public class PerfilsController(IPerfilService service) : ControllerBase
{
    #region </GetAll>
        [HttpGet("Perfils"), EndpointSummary("Obter Perfis")]
        public async Task<ActionResult> Get(CancellationToken token)
        {
            var response = await service.GetHandler(token);
            return Ok(response);
        }
    #endregion

    #region </GetById>
        [HttpGet("TPerfilById"), EndpointSummary("Obter Perfil Pelo Id")]
        public async Task<ActionResult> GetById([FromQuery] GetPerfilByIdCommand command, CancellationToken token)
        {
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Search>
        [HttpGet("SearchPerfil"), EndpointSummary("Pesquisar Perfil")]
        public async Task<ActionResult> Search([FromQuery] SearchPerfilCommand command, CancellationToken token)
        {
            var response = await service.SearchHendler(command,token);
            return Ok(response);
        }
    #endregion
}
