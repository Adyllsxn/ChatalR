namespace Kairos.Application.Abstractions.ExtensionsMethods.Usuario;
public static class UpdateUsuarioExtensions
{
    public static UpdateUsuarioResponse MapToUpdateUsuarioResponse(this UsuarioEntity entity)
    {
        return new UpdateUsuarioResponse
        {
            Id = entity.Id,
            Nome = entity.Nome,
            SobreNome = entity.SobreNome,
            Email = entity.Email,
            DataCadastro = entity.DataCadastro,
            Telefone = entity.Telefone,
            BI = entity.BI
        };
    }
}
