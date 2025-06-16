namespace Kairos.Application.UseCases.Blog.GetById;
public class GetBlogByIdCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
