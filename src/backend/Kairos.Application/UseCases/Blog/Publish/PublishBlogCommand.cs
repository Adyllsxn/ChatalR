namespace Kairos.Application.UseCases.Blog.Publish;
public class PublishBlogCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }

    [JsonIgnore]
    [Required(ErrorMessage = "Status de Postagem é obrigatório")]
    public EStatusPostagem StatusPostagem { get; set; } = EStatusPostagem.Publicado;
}
