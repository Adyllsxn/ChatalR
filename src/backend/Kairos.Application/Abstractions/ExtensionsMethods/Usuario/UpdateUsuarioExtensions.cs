namespace Kairos.Application.Abstractions.ExtensionsMethods.Usuario;
public static class UpdateUsuarioExtensions
{
    public static UsuarioEntity MapToUsuarioEntity(this UpdateUsuarioCommand command)
    {
        return new UsuarioEntity
        (
            command.Id,
            command.Nome,
            command.SobreNome,
            command.Email,
            command.PerfilID ?? 3,
            command.DataCadastro
        );
    }
    
    public static UpdateUsuarioResponse MapToUpdateUsuario (this UsuarioEntity entity)
    {
        return new UpdateUsuarioResponse
        {
            Id = entity.Id,
            Nome = entity.Nome,
            SobreNome = entity.SobreNome,
            Email = entity.Email,
            PerfilID = entity.PerfilID,
            DataCadastro = entity.DataCadastro
        };
    }
    public static IEnumerable<UpdateUsuarioResponse> MapToUpdateUsuario(this IEnumerable<UsuarioEntity> response)
    {
        return response.Select(entity => entity.MapToUpdateUsuario());
    }
}