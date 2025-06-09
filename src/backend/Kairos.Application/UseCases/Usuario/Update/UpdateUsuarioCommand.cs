namespace Kairos.Application.UseCases.Usuario.Update;
public class UpdateUsuarioCommand
{

    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }

    [Required( ErrorMessage = "Nome é obrigatório")]
    [MaxLength(50, ErrorMessage = "O Nome não pode ultrapassar de 50 caracteres")]
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
    [DataType(DataType.DateTime)]
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Telefone é obrigatório")]
    [MaxLength(20)]
    public string Telefone { get; set; } = null!;

    [Required(ErrorMessage = "BI é obrigatório")]
    [MaxLength(20)]
    public string BI { get; set; } = null!;

}
