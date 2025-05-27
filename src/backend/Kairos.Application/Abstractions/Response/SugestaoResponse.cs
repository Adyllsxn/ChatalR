namespace Kairos.Application.Abstractions.Response;
public record SugestaoResponse
{
    public int Id { get; set; }
    public int UsuarioID { get; set; }
    public int EventoID { get; set; }
    public string Conteudo { get; set; } = null!;
    public DateTime DataEnvio { get; set; }
}
