namespace Kairos.Application.Abstractions.ExtensionsMethods.Usuario;
public static class CreateUsuarioExtensions
{
    public static UsuarioEntity MapToUsuarioEntity(this CreateUsuarioCommand command)
    {

        return new UsuarioEntity
        (
            command.Nome,
            command.SobreNome,
            command.Email,
            command.PerfilID ?? 3,
            command.DataCadastro
        );
    }
    
    public static CreateUsuarioResponse MapToCreateUsuario (this UsuarioEntity entity)
    {
        return new CreateUsuarioResponse
        {
            Id = entity.Id,
            Nome = entity.Nome,
            SobreNome = entity.SobreNome,
            Email = entity.Email,
            PerfilID = entity.PerfilID,
            DataCadastro = entity.DataCadastro
        };
    }
    public static IEnumerable<CreateUsuarioResponse> MapToCreateUsuario(this IEnumerable<UsuarioEntity> response)
    {
        return response.Select(entity => entity.MapToCreateUsuario());
    }
}