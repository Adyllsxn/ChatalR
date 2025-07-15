namespace Kairos.Presentation.Source.Features.Usuario;
public class UsuarioUpdateFotoModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public IFormFile FotoUrl { get; set; } = null!;
}
