namespace Kairos.Application.UseCases.TipoEvento.Update;
public record UpdateTipoEventoCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "O Nome deve ter 50 no máximo caracteres")]
    [DataType(DataType.Text)]
    public string Nome { get; set; } = null!;
}
