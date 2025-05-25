namespace Kairos.Application.UseCases.Evento.GetById;
public class GetEventoByIdCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}