namespace Kairos.Application.Abstractions.ExtensionsMethods.Usuario;
public static class GetUsuarioByIdExtensions
{
    public static GetUsuarioByIdResponse MapToGetUsuarioById (this UsuarioEntity entity)
    {
        return new GetUsuarioByIdResponse
        {
            Id = entity.Id,
            Nome = entity.Nome,
            SobreNome = entity.SobreNome,
            Email = entity.Email,
            PerfilID = entity.PerfilID,
            Perfil = new PerfilResponse
            {
                Id = entity.Perfil.Id,
                Nome = entity.Perfil.Nome
            },
            DataCadastro = entity.DataCadastro
        };
    }
    public static IEnumerable<GetUsuarioByIdResponse> MapToGetUsuarioById(this IEnumerable<UsuarioEntity> response)
    {
        return response.Select(entity => entity.MapToGetUsuarioById());
    }
}