namespace Kairos.Application.UseCases.Sugestao.Delete;
public record DeleteSugestaoCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
