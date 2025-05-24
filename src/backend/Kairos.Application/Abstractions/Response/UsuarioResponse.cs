namespace Kairos.Application.Abstractions.Response;
public record UsuarioResponse
{
    public int Id { get; set; }
    public string Nome { get;  set; } = null!;
    public string SobreNome { get;  set; } = null!;
    public string Email { get;  set; } = null!;
    public int PerfilID { get;  set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}
