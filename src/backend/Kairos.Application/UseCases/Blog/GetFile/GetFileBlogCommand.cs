namespace Kairos.Application.UseCases.Blog.GetFile;
public class GetFileBlogCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
