namespace Kairos.Presentation.Features.Evento.Controller;
[ApiController]
[Route("v1/")]
[Authorize]
public class EventosController(IEventoService service, IUsuarioService usuario) : ControllerBase
{
    #region ListEvento
        [HttpGet("ListEvento")]
        [EndpointSummary("Listar todos os eventos.")]
        public async Task<ActionResult> ListEvento([FromQuery] GetEventosCommand command,CancellationToken token)
        {
            var response = await service.GetHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region GetPendentesEvento
        [HttpGet("GetPendentesEvento")]
        [EndpointSummary("Obter eventos pendentes.")]
        public async Task<ActionResult> GetPendentesEvento([FromQuery] GetEventosCommand command,CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1 || user.Data?.PerfilID == 2))
            {
                return Unauthorized("Você não tem permissão para visualizar evento.");
            }

            var response = await service.GePendentetHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region GetAprovadosEvento
        [HttpGet("GetAprovadosEvento")]
        [EndpointSummary("Obter eventos aprovados.")]
        public async Task<ActionResult> GetAprovadosEvento([FromQuery] GetEventosCommand command,CancellationToken token)
        {
            var response = await service.GetAprovadoHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region GetRejeitadosEvento
        [HttpGet("GetRejeitadosEvento")]
        [EndpointSummary("Obter eventos rejeitados.")]
        public async Task<ActionResult> GetRejeitadosEvento([FromQuery] GetEventosCommand command,CancellationToken token)
        {
            var response = await service.GetReijetadoHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region GetByIdEvento
        [HttpGet("GetByIdEvento")]
        [EndpointSummary("Obter evento pelo ID.")]
        public async Task<ActionResult> GetByIdEvento([FromQuery] GetEventoByIdCommand command, CancellationToken token)
        {
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region GetImagemEvento
        [HttpGet("GetImagemEvento")]
        [EndpointSummary("Obter imagem do evento.")]
        public async Task<ActionResult> GetImagemEvento([FromQuery] GetFileEventoCommand command, CancellationToken token)
        {
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }

                var userId = User.GetId();
                var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
                if(!(user.Data?.PerfilID == 1 || user.Data?.PerfilID == 2))
                {
                    return Unauthorized("Você não tem permissão para visualizar evento.");
                }

                var response = await service.GetFileHandler(command,token);
                if(response.Data?.ImagemUrl == null)
                {
                    return BadRequest("Imagem não encontrada");
                }
                var databyte = System.IO.File.ReadAllBytes(response.Data.ImagemUrl);
                return File(databyte, "image/jpg");
        }
    #endregion

    #region SearchEvento
        [HttpGet("SearchEvento")]
        [EndpointSummary("Pesquisar eventos por filtros.")]
        public async Task<ActionResult> SearchEvento([FromQuery] SearchEventoCommand command, CancellationToken token)
        {
            var response = await service.SearchHendler(command,token);
            return Ok(response);
        }
    #endregion

    #region CreateEvento
        [HttpPost("CreateEvento")]
        [EndpointSummary("Criar um novo evento.")]
        public async Task<ActionResult> CreateEvento([FromForm] CreateEventoModel model, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1 || user.Data?.PerfilID == 2))
            {
                return Unauthorized("Você não tem permissão para incluir um novo evento.");
            }

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

    #region UpdateStatusEvento
        [HttpPatch("UpdateStatusEvento")]
        [EndpointSummary("Atualizar status de aprovação do evento.")]
        public async Task<ActionResult> UpdateStatusEvento(UpdateEventoStatusCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1))
            {
                return Unauthorized("Você não tem permissão para aprovar evento.");
            }

            var response = await service.StatusHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region DeleteEvento
        [HttpDelete("DeleteEvento")]
        [EndpointSummary("Excluir evento pelo ID.")]
        public async Task<ActionResult> DeleteEvento([FromForm] UpdateEventoModel model, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == 1 || user.Data?.PerfilID == 2))
            {
                return Unauthorized("Você não tem permissão para atualizar o evento.");
            }


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

}
