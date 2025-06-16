namespace Kairos.Application.UseCases.Blog.Archive;
public class ArchiveBlogCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Status de Postagem é obrigatório")]
    public EStatusPostagem StatusPostagem { get; set; }
}
