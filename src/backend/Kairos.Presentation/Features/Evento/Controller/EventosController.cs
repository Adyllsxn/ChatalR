using Kairos.Application.UseCases.Evento.Status;

namespace Kairos.Presentation.Features.Evento.Controller;
[ApiController]
[Route("api/")]
public class EventosController(IEventoService service) : ControllerBase
{
    #region </GetAll>
        [HttpGet("Eventos"), EndpointSummary("Obter Eventos")]
        public async Task<ActionResult> GetAllAsync([FromQuery] GetEventosCommand command,CancellationToken token)
        {
            var response = await service.GetHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </GetById>
        [HttpGet("EventoById"), EndpointSummary("Obter Evento Pelo Id")]
        public async Task<ActionResult> GetById([FromQuery] GetEventoByIdCommand command, CancellationToken token)
        {
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </GetFile>
        [HttpGet("EventoImage"), EndpointSummary("Obter a imagem do Evento Pelo Id")]
        public async Task<ActionResult> GetFile([FromQuery] GetFileEventoCommand command, CancellationToken token)
        {
                var response = await service.GetFileHandler(command,token);
                if(response.Data?.ImagemUrl == null)
                {
                    return BadRequest("Imagem não encontrada");
                }
                var databyte = System.IO.File.ReadAllBytes(response.Data.ImagemUrl);
                return File(databyte, "image/jpg");
        }
    #endregion

    #region </Search>
        [HttpGet("SearchEvento"), EndpointSummary("Pesquisar Evento")]
        public async Task<ActionResult> Search([FromQuery] SearchEventoCommand command, CancellationToken token)
        {
            var response = await service.SearchHendler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Create>
        [HttpPost("CreateEvento"), EndpointSummary("Criar Evento")]
        public async Task<ActionResult> Create([FromForm] CreateEventoModel model, CancellationToken token)
        {
            if (model.ImagemUrl == null || model.ImagemUrl.Length == 0)
            {
                return BadRequest("Nenhuma imagem foi enviada.");
            }

            string pastaRaiz = "Storage";
            string pastaImagens = Path.Combine(pastaRaiz, "Images");
            if (!Directory.Exists(pastaImagens))
            {
                Directory.CreateDirectory(pastaImagens);
            }

            var extensao = Path.GetExtension(model.ImagemUrl.FileName).ToLower();
            var extensoesPermitidas = new HashSet<string> { ".jpg", ".jpeg", ".png", ".gif" };
            if (!extensoesPermitidas.Contains(extensao))
            {
                return BadRequest($"Extensão de arquivo não suportada: {extensao}. Permitidos: JPG, JPEG, PNG, GIF.");
            }

            string nomeArquivo = $"{Guid.NewGuid()}{extensao}";
            string caminhoCompleto = Path.Combine(pastaImagens, nomeArquivo);

            await using var stream = new FileStream(caminhoCompleto, FileMode.Create);
            await model.ImagemUrl.CopyToAsync(stream);

            var newCommand = new CreateEventoCommand{
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                DataHoraInicio = model.DataHoraInicio,
                DataHoraFim = model.DataHoraFim,
                Local = model.Local,
                TipoEventoID = model.TipoEventoID,
                UsuarioID = model.UsuarioID,
                ImagemUrl = caminhoCompleto
            };
            var response = await service.CreateHandler(newCommand,token);
            return Ok(response);
        }
    #endregion

    #region </Delete>
        [HttpDelete("DeleteEvento"), EndpointSummary("Excluir Evento")]
        public async Task<ActionResult> Delete([FromQuery] DeleteEventoCommand command, CancellationToken token)
        {
            var delete = new GetEventoByIdCommand{Id = command.Id};
            var result = await service.GetByIdHandler(delete, token);
            if (!string.IsNullOrEmpty(result.Data?.ImagemUrl) && System.IO.File.Exists(result.Data.ImagemUrl))
            {
                System.IO.File.Delete(result.Data.ImagemUrl);
            }
            var response = await service.DeleteHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Update>
        [HttpPut("UpdateEvento"), EndpointSummary("Editar Evento")]
        public async Task<ActionResult> Update([FromForm] UpdateEventoModel model, CancellationToken token)
        {
            var getCommand = new GetEventoByIdCommand { Id = model.Id };
            var result = await service.GetByIdHandler(getCommand, token);

            if (result.Data is null)
                return NotFound("Postagem não encontrada.");

            string caminhoAntigo = result.Data.ImagemUrl;
            string caminhoNovo = caminhoAntigo;

            if (model.ImagemUrl != null && model.ImagemUrl.Length > 0)
            {
                var extensao = Path.GetExtension(model.ImagemUrl.FileName).ToLower();
                var extensoesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!extensoesPermitidas.Contains(extensao))
                    return BadRequest("Extensão de imagem inválida. Use JPG, JPEG, PNG ou GIF.");

                string pasta = Path.Combine("Storage", "Images");
                Directory.CreateDirectory(pasta);

                string novoNome = $"{Guid.NewGuid()}{extensao}";
                caminhoNovo = Path.Combine(pasta, novoNome);

                await using var stream = new FileStream(caminhoNovo, FileMode.Create);
                await model.ImagemUrl.CopyToAsync(stream);

                if (System.IO.File.Exists(caminhoAntigo))
                    System.IO.File.Delete(caminhoAntigo);
            }

            var command = new UpdateEventoCommand
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                DataHoraInicio = model.DataHoraInicio,
                DataHoraFim = model.DataHoraFim,
                Local = model.Local,
                TipoEventoID = model.TipoEventoID,
                UsuarioID = model.UsuarioID,
                ImagemUrl = caminhoNovo
            };

            var response = await service.UpdateHendler(command, token);
            return Ok(response);
        }

    #endregion

    #region </Status>
        [HttpPut("UpdateStatusEvento"), EndpointSummary("Editar Status de AProvação de Evento")]
        public async Task<ActionResult> Update(UpdateEventoStatusCommand command, CancellationToken token)
        {
            var response = await service.StatusHandler(command,token);
            return Ok(response);
        }
    #endregion

}
