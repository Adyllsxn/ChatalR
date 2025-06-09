namespace Kairos.Application.UseCases.Usuario.Update;
public class UpdateUsuarioResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string SobreNome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    public string Telefone { get; set; } = null!;
    public string BI { get; set; } = null!;

}
