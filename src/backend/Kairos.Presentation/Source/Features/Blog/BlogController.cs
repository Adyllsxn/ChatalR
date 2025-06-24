namespace Kairos.Presentation.Source.Features.Blog;
[ApiController]
[Route("v1/")]
public class BlogController(IBlogService service) : ControllerBase
{
    #region List
        [HttpGet("ListBlog")]
        [EndpointSummary("Listando todos os posts do blog")]
        public async Task<ActionResult> ListBlog([FromQuery] GetBlogsCommand command, CancellationToken token) 
        { 
            var response = await service.GetHandler(command, token);
            return Ok(response);
        }
    #endregion

    #region GetById
        [HttpGet("GetByIdBlog")]
        [EndpointSummary("Retorna um post específico pelo ID")]
        public async Task<ActionResult> GetByIdBlog([FromQuery] GetBlogByIdCommand command, CancellationToken token) 
        { 
            var response = await service.GetByIdHandler(command, token);
            return Ok(response);
        }
    #endregion

    #region GetImage
        [HttpGet("GetImageBlog")]
        [EndpointSummary("Retorna imagem específico pelo ID")]
        public async Task<ActionResult> GetImageBlog([FromQuery] GetFileBlogCommand command, CancellationToken token) 
        { 
            var response = await service.GetFileHandler(command, token);
            return Ok(response);
        }
    #endregion
    
    #region GetPublish
        [HttpGet("GetPublishBlog")]
        [EndpointSummary("Retorna apenas posts publicados")]
        public async Task<ActionResult> GetPublishBlog([FromQuery] GetPublishBlogCommand command, CancellationToken token) 
        {
            var response = await service.GetPublishHandler(command, token);
            return Ok(response);
        }
    #endregion

    #region Search
        [HttpGet("SearchBlog")]
        [EndpointSummary("Pesquisa posts por critérios definidos")]
        public async Task<ActionResult> SearchBlog([FromQuery] SearchBlogCommand command, CancellationToken token) 
        {
            var response = await service.SearchHendler(command, token);
            return Ok(response);
        }
    #endregion

    #region Create
        [HttpPost("CreateBlog")]
        [EndpointSummary("Cria um novo post no blog")]
        public async Task<ActionResult> CreateBlog(CreateBlogCommand command, CancellationToken token)
        {
            var response = await service.CreateHandler(command, token);
            return Ok(response);
        }
    #endregion

    #region Edit
        [HttpPut("EditBlog")]
        [EndpointSummary("Edita completamente um post existente")]
        public async Task<ActionResult> EditBlog(UpdateBlogCommand command, CancellationToken token) { 
            var response = await service.UpdateHendler(command, token);
            return Ok(response);
        }
    #endregion

    #region Delete
        [HttpDelete("DeleteBlog")]
        [EndpointSummary("Remove um post do blog pelo ID")]
        public async Task<ActionResult> DeleteBlog([FromQuery] DeleteBlogCommand command, CancellationToken token) 
        {
            var response = await service.DeleteHandler(command, token);
            return Ok(response);
        }
    #endregion

    #region Archive
        [HttpPatch("ArchiveBlog")]
        [EndpointSummary("Arquiva um post do blog")]
        public async Task<ActionResult> ArchiveBlog(ArchiveBlogCommand command, CancellationToken token) 
        { 
            var response = await service.ArchiveHandler(command, token);
            return Ok(response);
        }
    #endregion

    #region Publish
        [HttpPatch("PublishBlog")]
        [EndpointSummary("Publicar um post do blog para visivel")]
        public async Task<ActionResult> PublishBlog(PublishBlogCommand command, CancellationToken token) 
        { 
            var response = await service.PublishHandler(command, token);
            return Ok(response);
        }
    #endregion

}

