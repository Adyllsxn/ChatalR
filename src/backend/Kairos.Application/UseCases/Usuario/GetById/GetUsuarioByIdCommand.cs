namespace Kairos.Application.UseCases.Usuario.GetById;
public record GetUsuarioByIdCommand
{
    [Required(ErrorMessage = "Número do ID é obrigatório")]
    public int Id { get; set; }
}