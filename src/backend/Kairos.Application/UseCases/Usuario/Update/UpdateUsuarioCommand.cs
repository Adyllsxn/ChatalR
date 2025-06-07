namespace Kairos.Application.UseCases.Usuario.Update;

public class UpdateUsuarioCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [MaxLength(100, ErrorMessage = "O Nome não pode ultrapassar 100 caracteres")]
    public string Nome { get; set; } = null!;

    [Required(ErrorMessage = "Sobrenome é obrigatório")]
    [MaxLength(50, ErrorMessage = "O Sobrenome não pode ultrapassar 50 caracteres")]
    public string SobreNome { get; set; } = null!;

    [Required(ErrorMessage = "Email é obrigatório")]
    [MaxLength(250, ErrorMessage = "Email não pode ultrapassar 250 caracteres")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [JsonIgnore]
    public int? PerfilID { get; set; }

    [JsonIgnore]
    [DataType(DataType.DateTime)]
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    [JsonIgnore]
    public bool IsActive { get; set; } = true;

    [JsonIgnore]
    [Required(ErrorMessage = "Senha é obrigatória")]
    [MinLength(4, ErrorMessage = "A senha deve conter no mínimo 4 caracteres.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Telefone é obrigatório")]
    [MaxLength(20)]
    public string Telefone { get; set; } = null!;

    [Required(ErrorMessage = "BI é obrigatório")]
    [MaxLength(20)]
    public string BI { get; set; } = null!;

    [Required(ErrorMessage = "Foto é obrigatória")]
    public string Foto { get; set; } = null!;
}
