namespace Kairos.Application.UseCases.Sugestao.MarkAsRead;
public record MarkAsReadSugestaoCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
