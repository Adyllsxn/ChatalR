namespace Kairos.Application.UseCases.Usuario.Delete;
public record DeleteUsuarioCommand
{
    [Required(ErrorMessage = "Número do ID é obrigatório")]
    public int Id { get; set; }
}