namespace Kairos.Application.UseCases.Sugestao.Update;
public record UpdateSugestaoCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Usuário é obrigatório")]
    public int UsuarioID { get; set; }

    [Required(ErrorMessage = "Evento é obrigatório")]
    public int EventoID { get; set; }

    [Required(ErrorMessage = "Conteudo é obrigatório")]
    [DataType(DataType.Text)]
    public string Conteudo { get; set; } = null!;

    [JsonIgnore]
    public DateTime DataEnvio { get; set; }
}
