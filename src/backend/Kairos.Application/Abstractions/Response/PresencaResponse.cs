namespace Kairos.Application.Abstractions.Response;
public record PresencaResponse
{
    public int Id { get; set; }
    public int UsuarioID { get; set; }
    public int EventoID { get; set; }
    public DateTime DataHoraCheckin { get; set; } = DateTime.UtcNow;
}
