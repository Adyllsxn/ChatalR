namespace Kairos.Application.UseCases.TipoEvento.Delete;
public class DeleteTipoEventoCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
