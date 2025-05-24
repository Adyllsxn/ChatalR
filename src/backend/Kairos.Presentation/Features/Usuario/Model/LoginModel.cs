namespace Kairos.Presentation.Features.Usuario.Model;
public record LoginModel
{
    [Required( ErrorMessage = " Email é obrigatório")]
    [MaxLength(250, ErrorMessage = "Email não pode ultrapassar de 200 caracteres")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password é obrigatório")]
    [MinLength(4, ErrorMessage = "A senha deve conter no mínimo 4 caracteres.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}