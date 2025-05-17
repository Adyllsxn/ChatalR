namespace Kairos.Domain.Entities;
public sealed class EventoEntity : EntityBase, IAgragateRoot
{
    public string Titulo { get; private set; } = null!;
    public string Descricao { get; private set; } = null!;
    public DateTime DataHoraInicio { get; private set; }
    public DateTime DataHoraFim { get; private set; }
    public string Local { get; private set; } = null!;
    public int TipoEventoID { get; private set; }
    public int UsuarioID { get; private set; }
    public EStatusAprovacao StatusAprovacao { get; private set; }
    public string ImagemUrl { get; private set; } = null!;

    [JsonIgnore]
    public TipoEventoEntity TipoEvento { get; private set; } = null!;

    [JsonIgnore]
    public UsuarioEntity Usuario { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<PresencaEntity> Presencas { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<SugestaoEntity> Sugestoes { get; private set; } = null!;

    [JsonConstructor]
    public EventoEntity(){}

    public EventoEntity(int id, string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, string imagemUrl)
    {
        DomainValidationException.When(id <= 0 , "ID deve ser maior que zero.");
        Id = id;
        ValidationDomain(titulo, descricao, dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, imagemUrl);
    }
    public EventoEntity(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, string imagemUrl)
    {
        ValidationDomain(titulo, descricao, dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, imagemUrl);
    }
    public void ValidationDomain(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, string imagemUrl)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(titulo), "Título é obrigatório.");
        DomainValidationException.When(titulo.Length > 100, "Título deve ter no máximo 100 caracteres.");

        DomainValidationException.When(string.IsNullOrWhiteSpace(descricao), "Descrição é obrigatória.");
        DomainValidationException.When(descricao.Length < 1, "Descrição deve ter no mínimo 1 caractere.");

        DomainValidationException.When(string.IsNullOrWhiteSpace(local), "Local é obrigatório.");
        DomainValidationException.When(local.Length > 250, "Local deve ter no máximo 250 caracteres.");

        DomainValidationException.When(tipoEventoID <= 0 , "Tipo de evento deve ser maior que zero.");
        DomainValidationException.When(usuarioID <= 0 , "Usuário deve ser maior que zero.");

        DomainValidationException.When(string.IsNullOrWhiteSpace(imagemUrl), "Imagem é obrigatória.");
        DomainValidationException.When(imagemUrl.Length < 1, "Imagem deve ter no mínimo 1 caractere.");


        Titulo = titulo;
        Descricao = descricao;
        DataHoraInicio = dataHoraInicio;
        DataHoraFim = dataHoraFim;
        Local = local;
        TipoEventoID = tipoEventoID;
        UsuarioID = usuarioID;
        StatusAprovacao = EStatusAprovacao.Pendente;
        ImagemUrl = imagemUrl;
    }
}
