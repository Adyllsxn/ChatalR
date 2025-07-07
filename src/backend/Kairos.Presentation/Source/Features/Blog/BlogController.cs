namespace Kairos.Presentation.Source.Features.Blog;
[ApiController]
[Route("v1/")]
[Authorize]
public class BlogController(IBlogService service, IUsuarioService usuario) : ControllerBase
{
    #region List
    [HttpGet("ListBlog")]
    [EndpointSummary("Listando todos os posts do blog")]
    public async Task<ActionResult> ListBlog([FromQuery] GetBlogsCommand command, CancellationToken token)
    {
        #region Authorize
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }
            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
            {
                return Unauthorized("Você não tem permissão para visualizar evento.");
            }
        #endregion

        #region ListBlog
            try
            {
                var response = await service.GetHandler(command, token);
                Logger.LogToFile("ListBlog - Success", "Listando todos os posts do blog.");
                return Ok(response);
            }
            catch (Exception error)
            {
                Logger.LogToFile("ListBlog - Error", $"Error {error.Message}");
                return Problem($"Error: {error.Message}");
            }
        #endregion
    }
    #endregion

    #region GetById
    [HttpGet("GetByIdBlog")]
    [EndpointSummary("Retorna um post específico pelo ID")]
    public async Task<ActionResult> GetByIdBlog([FromQuery] GetBlogByIdCommand command, CancellationToken token)
    {
        #region Authorize
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }
            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
            {
                return Unauthorized("Você não tem permissão para visualizar evento.");
            }
        #endregion
        
        #region GetByIdBlog
            try
            {
                var response = await service.GetByIdHandler(command, token);
                Logger.LogToFile(
                        "GetByIdBlog - Success", 
                        "Retorna um post específico pelo ID"
                    );
                return Ok(response);
            }
            catch (Exception error)
            {
                Logger.LogToFile(
                        "GetByIdBlog, - Error", 
                        $"Error: {error.Message}"
                    );
                return Problem($"Error: {error.Message}");
            }
        #endregion
    }
    #endregion

    #region GetImage
    [HttpGet("GetImageBlog")]
    [EndpointSummary("Retorna imagem específico pelo ID")]
    public async Task<ActionResult> GetImageBlog([FromQuery] GetFileBlogCommand command, CancellationToken token)
    {
        #region Authorize
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }
            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
            {
                return Unauthorized("Você não tem permissão para visualizar evento.");
            }
        #endregion

        #region GetImageBlog
            try
            {
                var response = await service.GetFileHandler(command, token);
                if(response.Data?.ImagemCapaUrl == null)
                {
                    return BadRequest("Imagem não encontrada");
                }
                var databyte = System.IO.File.ReadAllBytes(response.Data.ImagemCapaUrl);
                return File(databyte, "image/jpg");
            }
            catch (Exception error)
            {
                Logger.LogToFile("GetImageBlog - Error", $"Error: {error.Message}");
                return Problem($"Error: {error.Message}");
            }
        #endregion
    }
    #endregion

    #region GetPublish
    [HttpGet("GetPublishBlog")]
    [EndpointSummary("Retorna apenas posts publicados")]
    public async Task<ActionResult> GetPublishBlog([FromQuery] GetPublishBlogCommand command, CancellationToken token)
    {
        #region Authorize
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }
            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
            {
                return Unauthorized("Você não tem permissão para visualizar evento.");
            }
        #endregion

        #region GetPublishBlog
            try
            {
                var response = await service.GetPublishHandler(command, token);
                return Ok(response);
            }
            catch(Exception error)
            {
                return Problem($"Error: {error.Message}");
            }
        #endregion
    }
    #endregion

    #region Search
    [HttpGet("SearchBlog")]
    [EndpointSummary("Pesquisa posts por critérios definidos")]
    public async Task<ActionResult> SearchBlog([FromQuery] SearchBlogCommand command, CancellationToken token)
    {
        #region Authorize
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }
            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
            {
                return Unauthorized("Você não tem permissão para visualizar evento.");
            }
        #endregion
        
        #region SearchBlog
            try
            {
                var response = await service.SearchHendler(command, token);
                return Ok(response);
            }
            catch(Exception error)
            {
                return Problem($"Error: {error.Message}");
            }
        #endregion
    }
    #endregion

    #region Create
    [HttpPost("CreateBlog")]
    [EndpointSummary("Cria um novo post no blog")]
    public async Task<ActionResult> CreateBlog([FromForm] BlogCreateModel model, CancellationToken token)
    {
        #region Authorize
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }
            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
            {
                return Unauthorized("Você não tem permissão para visualizar evento.");
            }
        #endregion

        #region CreateBlog
            try
            {
                if (model.ImagemCapaUrl == null || model.ImagemCapaUrl.Length == 0)
                {
                    return BadRequest("Nenhuma imagem foi enviada.");
                }

                string pastaRaiz = "Storage";
                string pastaImagens = Path.Combine(pastaRaiz, "Images");
                if (!Directory.Exists(pastaImagens))
                {
                    Directory.CreateDirectory(pastaImagens);
                }

                var extensao = Path.GetExtension(model.ImagemCapaUrl.FileName).ToLower();
                var extensoesPermitidas = new HashSet<string> { ".jpg", ".jpeg", ".png", ".gif" };
                if (!extensoesPermitidas.Contains(extensao))
                {
                    return BadRequest($"Extensão de arquivo não suportada: {extensao}. Permitidos: JPG, JPEG, PNG, GIF.");
                }

                string nomeArquivo = $"{Guid.NewGuid()}{extensao}";
                string caminhoCompleto = Path.Combine(pastaImagens, nomeArquivo);

                await using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                await model.ImagemCapaUrl.CopyToAsync(stream);

                var newCommand = new CreateBlogCommand{
                    UsuarioID = userId,
                    Titulo = model.Titulo,
                    Conteudo = model.Conteudo,
                    ImagemCapaUrl = caminhoCompleto
                };
                var response = await service.CreateHandler(newCommand, token);
                return Ok(response);
            }
            catch(Exception error)
            {
                return Problem($"Error: {error.Message}");
            }
        #endregion
    }
    #endregion

    #region Edit
    [HttpPut("EditBlog")]
    [EndpointSummary("Edita completamente um post existente")]
    public async Task<ActionResult> EditBlog([FromForm] BlogUpdateModel model, CancellationToken token)
    {
        #region Authorize
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }
            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
            {
                return Unauthorized("Você não tem permissão para visualizar evento.");
            }
        #endregion
        
        #region EditBlog
            try
            {
                var getCommand = new GetBlogByIdCommand { Id = model.Id };
                var result = await service.GetByIdHandler(getCommand, token);

                if (result.Data is null)
                    return NotFound("Postagem não encontrada.");

                string caminhoAntigo = result.Data.ImagemCapaUrl;
                string caminhoNovo = caminhoAntigo;

                if (model.ImagemCapaUrl != null && model.ImagemCapaUrl.Length > 0)
                {
                    var extensao = Path.GetExtension(model.ImagemCapaUrl.FileName).ToLower();
                    var extensoesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    if (!extensoesPermitidas.Contains(extensao))
                        return BadRequest("Extensão de imagem inválida. Use JPG, JPEG, PNG ou GIF.");

                    string pasta = Path.Combine("Storage", "Images");
                    Directory.CreateDirectory(pasta);

                    string novoNome = $"{Guid.NewGuid()}{extensao}";
                    caminhoNovo = Path.Combine(pasta, novoNome);

                    await using var stream = new FileStream(caminhoNovo, FileMode.Create);
                    await model.ImagemCapaUrl.CopyToAsync(stream);

                    if (System.IO.File.Exists(caminhoAntigo))
                        System.IO.File.Delete(caminhoAntigo);
                }

                var command = new UpdateBlogCommand
                {
                    Id = model.Id,
                    UsuarioID = userId,
                    Titulo = model.Titulo,
                    Conteudo = model.Conteudo,
                    ImagemCapaUrl = caminhoNovo
                };
                var response = await service.UpdateHendler(command, token);
                return Ok(response);
            }
            catch(Exception error)
            {
                return Problem($"Error: {error.Message}");
            }
        #endregion
    }
    #endregion

    #region Archive
    [HttpPatch("ArchiveBlog")]
    [EndpointSummary("Arquiva um post do blog")]
    public async Task<ActionResult> ArchiveBlog(ArchiveBlogCommand command, CancellationToken token)
    {
        #region Authorize
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }
            var userId = User.GetId();
            var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
            {
                return Unauthorized("Você não tem permissão para visualizar evento.");
            }
        #endregion

        #region ArchiveBlog
            try
            {
                var response = await service.ArchiveHandler(command, token);
                return Ok(response);
            }
            catch(Exception error)
            {
                return Problem($"Error: {error.Message}");
            }
        #endregion
    }
    #endregion

    #region Publish
        [HttpPatch("PublishBlog")]
        [EndpointSummary("Publicar um post do blog para visivel")]
        public async Task<ActionResult> PublishBlog(PublishBlogCommand command, CancellationToken token)
        {
            #region Authorize
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }
                var userId = User.GetId();
                var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
                if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
                {
                    return Unauthorized("Você não tem permissão para visualizar evento.");
                }
            #endregion

            #region PublishBlog
                try
                {
                    var response = await service.PublishHandler(command, token);
                    return Ok(response);
                }
                catch(Exception error)
                {
                    return Problem($"Error: {error.Message}");
                }
            #endregion
        }
    #endregion

    #region Delete
        [HttpDelete("DeleteBlog")]
        [EndpointSummary("Remove um post do blog pelo ID")]
        public async Task<ActionResult> DeleteBlog([FromQuery] DeleteBlogCommand command, CancellationToken token)
        {
            #region Authorize
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }
                var userId = User.GetId();
                var user = await usuario.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
                if(!(user.Data?.PerfilID == PerfilConstant.Adm || user.Data?.PerfilID == PerfilConstant.Organizador))
                {
                    return Unauthorized("Você não tem permissão para visualizar evento.");
                }
            #endregion
            
            #region 
                try
                {
                    var response = await service.DeleteHandler(command, token);
                    return Ok(response);
                }
                catch(Exception error)
                {
                    return Problem($"Error: {error.Message}");
                }
            #endregion
        }
    #endregion

}

