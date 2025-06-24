namespace Kairos.Presentation.Source.Features.Usuario;
public class UsuarioUpdateFotoModel
{
    public int Id { get; set; }
    public IFormFile FotoUrl { get; set; } = null!;
}
