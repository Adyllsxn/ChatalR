namespace Kairos.Application.UseCases.Usuario.Status;
public class UsuarioStatusCommand
{
    public int Id { get; set; }
    public PerfilResponse Perfil { get; set; } = null!; 
}
