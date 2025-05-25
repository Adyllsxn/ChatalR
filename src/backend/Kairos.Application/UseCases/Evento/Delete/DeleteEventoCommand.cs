namespace Kairos.Application.UseCases.Evento.Delete;
public record DeleteEventoCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
