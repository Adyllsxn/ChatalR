namespace Kairos.Application.Abstractions.ExtensionsMethods.Usuario;
public static class StatusUsaurioExtensions
{
    public static UsuarioStatusResponse MapToUsuarioStatusResponse(this UsuarioEntity entity)
    {
        return new UsuarioStatusResponse
        {
            Id = entity.Id,
            PerfilID = entity.PerfilID
            
        };
    }
}
