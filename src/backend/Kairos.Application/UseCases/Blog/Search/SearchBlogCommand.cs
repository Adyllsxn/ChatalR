namespace Kairos.Application.UseCases.Blog.Search;
public class SearchBlogCommand
{
    [Required(ErrorMessage = "Titulo é obrigatório")]
    [MaxLength(100, ErrorMessage = "Título deve ter no máximo 100 caracteres.")]
    [DataType(DataType.Text)]
    public string Titulo { get; set; } = null!;
}
