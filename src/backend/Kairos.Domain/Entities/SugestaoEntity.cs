namespace Kairos.Domain.Entities;
public class SugestaoEntity: EntityBase, IAgragateRoot
{
    public int UsuarioID { get; private set; }
    public int EventoID { get; private set; }
    public string Conteudo { get; private set; } = null!;
    public DateTime DataEnvio { get; private set; }
    public EStatusSugestao StatusSugestao { get; private set; }

    [JsonIgnore]
    public UsuarioEntity Usuario { get; private set; } = null!;

    [JsonIgnore]
    public EventoEntity Evento { get; private set; } = null!;

    [JsonConstructor]
    public SugestaoEntity(){}

    public SugestaoEntity(int id, int usuarioID, int eventoID, string conteudo, DateTime dataEnvio)
    {
        DomainValidationException.When(id <= 0 , "ID deve ser maior que zero.");
        Id = id;
        ValidationDomain(usuarioID, eventoID, conteudo, dataEnvio);
    }

    public SugestaoEntity(int usuarioID, int eventoID, string conteudo, DateTime dataEnvio)
    {
        ValidationDomain(usuarioID, eventoID, conteudo, dataEnvio);
    }

    public void ValidationDomain(int usuarioID, int eventoID, string conteudo, DateTime dataEnvio)
    {

        DomainValidationException.When(string.IsNullOrWhiteSpace(conteudo), "Conteudo é obrigatório.");
        DomainValidationException.When(conteudo.Length < 1, "Conteudo deve ter no mínimo 1 caracteres.");

        DomainValidationException.When(usuarioID <= 0 , "ID do Usuário deve ser maior que zero.");
        DomainValidationException.When(eventoID <= 0 , "ID do Evento deve ser maior que zero.");

        UsuarioID = usuarioID;
        EventoID = eventoID;
        Conteudo = conteudo;
        DataEnvio = dataEnvio;
        StatusSugestao = EStatusSugestao.Nova;
    }
}
