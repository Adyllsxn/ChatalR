namespace Kairos.Application.UseCases.Usuario.Update;
public record UpdateUsuarioCommand
{
    [JsonIgnore]
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }

    [Required( ErrorMessage = "Nome é obrigatório")]
    [MaxLength(100, ErrorMessage = "O Nome não pode ultrapassar de 100 caracteres")]
    [DataType(DataType.Text)]
    public string Nome { get; set; } = null!;

    [Required( ErrorMessage = "SobreNome é obrigatório")]
    [MaxLength(50, ErrorMessage = "O SobreNome não pode ultrapassar de 50 caracteres")]
    [DataType(DataType.Text)]
    public string SobreNome { get; set; } = null!;

    [Required( ErrorMessage = " Email é obrigatório")]
    [MaxLength(250, ErrorMessage = "Email não pode ultrapassar de 250 caracteres")]
    [DataType(DataType.EmailAddress)]
    
    public string Email { get; set; } = null!;

    [JsonIgnore]
    public int? PerfilID { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; } = true;

    [Required(ErrorMessage = "Password é obrigatório")]
    [MinLength(4, ErrorMessage = "A senha deve conter no mínimo 4 caracteres.")]
    [DataType(DataType.Password)]
    [NotMapped]
    public string Password { get; set; } = null!;
}
