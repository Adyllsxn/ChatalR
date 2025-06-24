namespace Kairos.Presentation.Source.Features.Auth;
public class TokenModel
{
    public string Token { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string SobreNome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PerfilID { get; set; }
}
