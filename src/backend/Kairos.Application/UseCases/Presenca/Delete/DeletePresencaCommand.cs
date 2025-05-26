namespace Kairos.Application.UseCases.Presenca.Delete;
public record DeletePresencaCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
