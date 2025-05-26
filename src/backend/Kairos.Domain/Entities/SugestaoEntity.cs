namespace Kairos.Domain.Entities;
public class SugestaoEntity : EntityBase, IAgragateRoot
{
    public int UsuarioID { get; private set; }
    public int EventoID { get; private set; }
    public string Conteudo { get; private set; } = null!;
    public string Resposta { get; private set; } = null!;

    public DateTime DataEnvio { get; private set; }
    public EStatusSugestao StatusSugestao { get; private set; }

    [JsonIgnore]
    public UsuarioEntity Usuario { get; private set; } = null!;

    [JsonIgnore]
    public EventoEntity Evento { get; private set; } = null!;

    [JsonConstructor]
    public SugestaoEntity() {}

    public SugestaoEntity(int id, int usuarioID, int eventoID, string conteudo, DateTime dataEnvio)
    {
        DomainValidationException.When(id <= 0, "ID deve ser maior que zero.");
        Id = id;
        ValidationDomain(usuarioID, eventoID, conteudo, dataEnvio);
    }

    public SugestaoEntity(int usuarioID, int eventoID, string conteudo, DateTime dataEnvio)
    {
        ValidationDomain(usuarioID, eventoID, conteudo, dataEnvio);
    }

    public void ValidationDomain(int usuarioID, int eventoID, string conteudo, DateTime dataEnvio)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(conteudo), "Conteúdo é obrigatório.");
        DomainValidationException.When(conteudo.Length < 1, "Conteúdo deve ter no mínimo 1 caractere.");
        DomainValidationException.When(usuarioID <= 0, "ID do Usuário deve ser maior que zero.");
        DomainValidationException.When(eventoID <= 0, "ID do Evento deve ser maior que zero.");

        UsuarioID = usuarioID;
        EventoID = eventoID;
        Conteudo = conteudo;
        DataEnvio = dataEnvio;
        StatusSugestao = EStatusSugestao.Nova;
    }

    public void AtualizarConteudo(string novoConteudo)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(novoConteudo), "Conteúdo é obrigatório.");
        DomainValidationException.When(novoConteudo.Length < 1, "Conteúdo deve ter no mínimo 1 caractere.");
        Conteudo = novoConteudo;
    }

    public void MarcarComoEmAnalise()
    {
        DomainValidationException.When(StatusSugestao != EStatusSugestao.Nova,
            "Apenas sugestões novas podem ser marcadas como 'Em Análise'.");
        StatusSugestao = EStatusSugestao.EmAnalise;
    }

    public void Aprovar()
    {
        DomainValidationException.When(StatusSugestao != EStatusSugestao.EmAnalise,
            "Apenas sugestões em análise podem ser aprovadas.");
        StatusSugestao = EStatusSugestao.Aprovada;
    }

    public void Rejeitar()
    {
        DomainValidationException.When(StatusSugestao != EStatusSugestao.EmAnalise,
            "Apenas sugestões em análise podem ser rejeitadas.");
        StatusSugestao = EStatusSugestao.Rejeitada;
    }

    public void Responder(string resposta)
    {
        DomainValidationException.When(StatusSugestao != EStatusSugestao.Aprovada &&
                                       StatusSugestao != EStatusSugestao.Rejeitada,
            "Apenas sugestões aprovadas ou rejeitadas podem ser respondidas.");

        DomainValidationException.When(string.IsNullOrWhiteSpace(resposta),
            "A resposta não pode ser vazia.");

        Resposta = resposta;
        StatusSugestao = EStatusSugestao.Respondida;
    }

    public void AtualizarStatus(EStatusSugestao novoStatus)
    {
        StatusSugestao = novoStatus;
    }
}
