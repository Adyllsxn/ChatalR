namespace Kairos.Domain.Entities;
public sealed class UsuarioEntity : EntityBase, IAgragateRoot
{
    public string Nome { get; private set; } = null!;
    public string SobreNome { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public int PerfilID { get; private set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; private set; }
    public byte[] PasswordHash { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;

    public string Telefone { get; private set; } = null!;
    public string BI { get; private set; } = null!;
    public string Foto { get; private set; } = null!;

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
    public UsuarioEntity(int id, string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro, string telefone, string bi, string foto)
    {
        DomainValidationException.When(id <= 0 , "ID deve ser maior que zero.");
        Id = id;
        ValidationDomain(nome, sobrenome, email, perfilID, dataCadastro, telefone, bi, foto);
    }
    public UsuarioEntity(string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro, string telefone, string bi, string foto)
    {
        ValidationDomain(nome, sobrenome, email, perfilID, dataCadastro, telefone, bi, foto);
    }
    public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
    public void AlterarFoto(string novaFoto)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(novaFoto), "Foto é obrigatória.");
        Foto = novaFoto;
    }
    public void Deactivate()
    {
        IsActive = false;
    }

    public void ValidationDomain(string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro, string telefone, string bi, string foto)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(nome), "Nome é obrigatório.");
        DomainValidationException.When(nome.Length > 50, "Nome deve ter no máximo 50 caracteres.");

        DomainValidationException.When(string.IsNullOrWhiteSpace(sobrenome), "SobreNome é obrigatório.");
        DomainValidationException.When(sobrenome.Length > 50, "SobreNome deve ter no máximo 50 caracteres.");

        DomainValidationException.When(string.IsNullOrWhiteSpace(email), "Email é obrigatório.");
        DomainValidationException.When(email.Length > 250, "Email deve ter no máximo 250 caracteres.");

        DomainValidationException.When(perfilID <= 0, "ID deve ser maior que zero.");

        // Telefone
        var telefoneRegex = new Regex(@"^(\+244\s?)?[9]\d{2}\s?\d{3}\s?\d{3}$");
        DomainValidationException.When(string.IsNullOrWhiteSpace(telefone), "Telefone é obrigatório.");
        DomainValidationException.When(!telefoneRegex.IsMatch(telefone), "Telefone inválido.");

        var biRegex = new Regex(@"^\d{9}[A-Z]{2}\d{3}$");
        DomainValidationException.When(string.IsNullOrWhiteSpace(bi), "BI é obrigatório.");
        DomainValidationException.When(!biRegex.IsMatch(bi), "BI inválido.");

        DomainValidationException.When(string.IsNullOrWhiteSpace(foto), "Foto é obrigatória.");

        Nome = nome;
        SobreNome = sobrenome;
        Email = email;
        PerfilID = perfilID;
        DataCadastro = dataCadastro;
        IsActive = true;
        Telefone = telefone;
        BI = bi;
        Foto = foto;
    }
}
