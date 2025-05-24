namespace Kairos.Application.UseCases.Perfil.GetById;
public class GetPerfilByIdCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
