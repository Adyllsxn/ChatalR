namespace Kairos.Presentation.Source.Features.Evento;
public class EventoUpdateModel
{   
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Titulo é obrigatório")]
    [MaxLength(100, ErrorMessage = "Título deve ter no máximo 100 caracteres.")]
    [DataType(DataType.Text)]
    public string Titulo { get; set; } = null!;

    [Required(ErrorMessage = "Descrição é obrigatório")]
    [MinLength(1, ErrorMessage = "Descrição deve ter no mínimo 1 caractere.")]
    [DataType(DataType.Text)]
    public string Descricao { get; set; } = null!;

    [Required(ErrorMessage = "Data de Início é obrigatório")]
    [DataType(DataType.Date)]
    public DateTime DataHoraInicio { get; set; }

    [Required(ErrorMessage = "Data de Fim é obrigatório")]
    [DataType(DataType.Date)]
    public DateTime DataHoraFim { get; set; }

    [Required(ErrorMessage = "Local é obrigatório")]
    [MaxLength(250, ErrorMessage = "Local deve ter no máximo 250 caracteres.")]
    [DataType(DataType.Text)]
    public string Local { get; set; } = null!;

    [Required(ErrorMessage = "Tipo de Evento é obrigatório")]
    public int TipoEventoID { get; set; }

    [Required(ErrorMessage = "Usuário é obrigatório")]
    public int UsuarioID { get; set; }

    [Required(ErrorMessage = "ImagemUrl é obrigatório")]
    public IFormFile ImagemUrl { get; set; } = null!;
}
