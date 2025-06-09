namespace Kairos.Domain.Entities;
public sealed class UsuarioEntity : EntityBase, IAgragateRoot
{
    public string Nome { get; private set; } = null!;
    public string SobreNome { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public int PerfilID { get; private set; }
    public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;
    public bool IsActive { get; private set; }
    public byte[] PasswordHash { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;
    public string Telefone { get; private set; } = null!;
    public string BI { get; private set; } = null!;

    [JsonIgnore]
    public PerfilEntity Perfil { get; private set; } = null!;
    [JsonIgnore]
    public ICollection<EventoEntity> Eventos { get; private set; } = null!;
    [JsonIgnore]
    public ICollection<PresencaEntity> Presencas { get; private set; } = null!;
    [JsonIgnore]
    public ICollection<SugestaoEntity> Sugestoes { get; private set; } = null!;

    [JsonConstructor]
    public UsuarioEntity() { }

    // Construtor com ID
    public UsuarioEntity(int id, string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro, string telefone, string bi)
    {
        DomainValidationException.When(id <= 0, "ID deve ser maior que zero.");
        Id = id;
        ValidarDados(nome, sobrenome, email, perfilID, dataCadastro, telefone, bi);
    }

    // Construtor sem ID
    public UsuarioEntity(string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro, string telefone, string bi)
    {
        ValidarDados(nome, sobrenome, email, perfilID, dataCadastro, telefone, bi);
    }

    // Atualizar apenas a senha
    public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    // Atualizar dados do usuário (sem senha ou perfil)
    public void UpdateInfo(int id, string nome, string sobrenome, string email, DateTime dataCadastro, string telefone, string bi)
    {
        DomainValidationException.When(id <= 0, "ID deve ser maior que zero.");
        Id = id;
        ValidarDados(nome, sobrenome, email, PerfilID, dataCadastro, telefone, bi);
    }

    // Atualizar apenas o perfil
    public void UpdatePerfil(int perfilId)
    {
        DomainValidationException.When(perfilId <= 0, "Perfil inválido.");
        PerfilID = perfilId;
    }

    public void Deactivate() => IsActive = false;

    private void ValidarDados(string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro, string telefone, string bi)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(nome), "Nome é obrigatório.");
        DomainValidationException.When(nome.Length > 50, "Nome deve ter no máximo 50 caracteres.");

        DomainValidationException.When(string.IsNullOrWhiteSpace(sobrenome), "SobreNome é obrigatório.");
        DomainValidationException.When(sobrenome.Length > 50, "SobreNome deve ter no máximo 50 caracteres.");

        DomainValidationException.When(string.IsNullOrWhiteSpace(email), "Email é obrigatório.");
        DomainValidationException.When(email.Length > 250, "Email deve ter no máximo 250 caracteres.");

        DomainValidationException.When(perfilID <= 0, "PerfilID deve ser maior que zero.");

        var telefoneRegex = new Regex(@"^(\+244\s?)?[9]\d{2}\s?\d{3}\s?\d{3}$");
        DomainValidationException.When(string.IsNullOrWhiteSpace(telefone), "Telefone é obrigatório.");
        DomainValidationException.When(!telefoneRegex.IsMatch(telefone), "Telefone inválido.");

        var biRegex = new Regex(@"^\d{9}[A-Z]{2}\d{3}$");
        DomainValidationException.When(string.IsNullOrWhiteSpace(bi), "BI é obrigatório.");
        DomainValidationException.When(!biRegex.IsMatch(bi), "BI inválido.");

        Nome = nome;
        SobreNome = sobrenome;
        Email = email;
        PerfilID = perfilID;
        DataCadastro = dataCadastro;
        IsActive = true;
        Telefone = telefone;
        BI = bi;
    }
}
