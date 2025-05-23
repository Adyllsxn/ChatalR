namespace Kairos.Application.UseCases.TipoEvento.Create;
public record CreateTipoEventoCommand
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [MaxLength(60, ErrorMessage = "O Nome deve ter 60 no máximo caracteres")]
    [DataType(DataType.Text)]
    public string Nome { get; set; } = null!;
}
