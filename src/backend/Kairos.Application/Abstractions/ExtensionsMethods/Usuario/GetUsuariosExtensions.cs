namespace Kairos.Application.Abstractions.ExtensionsMethods.Usuario;
public static class GetUsuariosExtensions
{
    public static GetUsuariosResponse MapToGetUsuarios (this UsuarioEntity entity)
    {
        return new GetUsuariosResponse
        {
            Id = entity.Id,
            Nome = entity.Nome,
            SobreNome = entity.SobreNome,
            Email = entity.Email,
            PerfilID = entity.PerfilID,
            DataCadastro = entity.DataCadastro
        };
    }
    public static IEnumerable<GetUsuariosResponse> MapToGetUsuarios(this IEnumerable<UsuarioEntity> response)
    {
        return response.Select(entity => entity.MapToGetUsuarios());
    }
}