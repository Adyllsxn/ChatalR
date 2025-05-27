namespace Kairos.Application.UseCases.Sugestao.GetById;
public record GetSugestaoByIdCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
