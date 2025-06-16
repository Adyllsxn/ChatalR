namespace Kairos.Application.Abstractions.Response;
public record BlogResponse
{
    public int Id { get; set; }
    public int UsuarioID { get; set; }
    public UsuarioResponse Usuario { get; set; } = null!;
    public string Titulo { get; set; } = null!;
    public string Conteudo { get; set; } = null!;
    public string ImagemCapaUrl { get; set; } = null!;
    public DateTime DataPublicacao { get; set; }
}
