namespace Kairos.Application.UseCases.Blog.Delete;
public class DeleteBlogCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
