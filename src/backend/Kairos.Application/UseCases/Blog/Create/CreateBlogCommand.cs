namespace Kairos.Application.UseCases.Blog.Create;
public class CreateBlogCommand
{
    [Required(ErrorMessage = "ID do autor deve ser maior que zero.")]
    public int UsuarioID { get; set; }

    [Required(ErrorMessage = "Título é obrigatório")]
    [MinLength(3, ErrorMessage = "Título deve ter no mínimo 3 caracteres.")]
    [DataType(DataType.Text)]
    public string Titulo { get; set; } = null!;

    [Required(ErrorMessage = "Conteudo é obrigatório")]
    [MinLength(10, ErrorMessage = "Conteúdo deve ter no mínimo 10 caracteres.")]
    [DataType(DataType.Text)]
    public string Conteudo { get; set; } = null!;

    [Required(ErrorMessage = "ImagemCapaUrl é obrigatório")]
    [MinLength(1, ErrorMessage = "ImagemCapaUrl deve ter no mínimo 1 caracteres.")]
    public string ImagemCapaUrl { get; set; } = null!;

    [JsonIgnore]
    public DateTime DataPublicacao { get; set; }

    [JsonIgnore]
    public EStatusPostagem Status { get; private set; } = EStatusPostagem.Rascunho;
}
