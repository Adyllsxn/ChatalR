namespace Kairos.Application.UseCases.TipoEvento.GetById;
public record GetTipoEventoByIdCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
