namespace Kairos.Application.UseCases.Presenca.Create;
public class CreatePresencaCommand
{   
    [Required(ErrorMessage = "Usuário é obrigatório")]
    public int UsuarioID { get; set; }

    [Required(ErrorMessage = "Evento é obrigatório")]
    public int EventoID { get; set; }

    [JsonIgnore]
    public DateTime DataHoraCheckin { get; set; } = DateTime.UtcNow;
}
