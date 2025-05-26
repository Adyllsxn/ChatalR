namespace Kairos.Application.UseCases.Presenca.GetById;
public record GetPresencaByIdCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
