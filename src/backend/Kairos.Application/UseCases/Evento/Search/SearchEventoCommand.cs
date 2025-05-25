namespace Kairos.Application.UseCases.Evento.Search;
public record SearchEventoCommand
{
    [Required(ErrorMessage = "Titulo é obrigatório")]
    [MaxLength(100, ErrorMessage = "Título deve ter no máximo 100 caracteres.")]
    [DataType(DataType.Text)]
    public string Titulo { get; set; } = null!;
    
}
