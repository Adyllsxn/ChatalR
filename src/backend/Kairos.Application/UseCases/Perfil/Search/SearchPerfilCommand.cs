namespace Kairos.Application.UseCases.Perfil.Search;
public record SearchPerfilCommand
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [DataType(DataType.Text)]
    public string Nome { get; set; } = null!;
}
