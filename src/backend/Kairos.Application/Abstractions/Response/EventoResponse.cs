namespace Kairos.Application.Abstractions.Response;
public record EventoResponse
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public string Local { get; set; } = null!;
    public int TipoEventoID { get; set; }
    public TipoEventoResponse TipoEvento { get; set; } = null!;
    public int UsuarioID { get; set; }
    public UsuarioResponse Usuario { get; set; } = null!;
    public EAprovacao StatusAprovacao { get; set; }
    public string ImagemUrl { get; set; } = null!;
}
