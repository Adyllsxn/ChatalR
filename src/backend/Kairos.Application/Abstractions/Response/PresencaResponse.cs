namespace Kairos.Application.Abstractions.Response;
public record PresencaResponse
{
    public int Id { get; set; }
    public int UsuarioID { get; set; }
    public UsuarioResponse Usuario { get; set; } = null!;
    public int EventoID { get; set; }
    public EventoResponse Evento { get;  set; } = null!;
    public DateTime DataHoraCheckin { get; set; } = DateTime.UtcNow;
}
