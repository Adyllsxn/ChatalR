namespace Kairos.Application.UseCases.Usuario.Search;
public record SearchUsuarioCommand
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [DataType(DataType.Text)]
    public string Nome { get; set; } = null!;
}