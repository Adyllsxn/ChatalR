namespace Kairos.Domain.Entities;
public record DashboardEntity
{
    public int QtdTipoEvento { get; set; }
    public int QtdPerfil { get; set; }
    public int QtdEvento { get; set; }
    public int QtdUsuario { get; set; }
    public int QtdPresenca { get; set; }
    public int QtdSugestao { get; set; }
}
