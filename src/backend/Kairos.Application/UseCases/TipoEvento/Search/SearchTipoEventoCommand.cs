namespace Kairos.Application.UseCases.TipoEvento.Search;
public class SearchTipoEventoCommand
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [DataType(DataType.Text)]
    public string Nome { get; set; } = null!;
}
