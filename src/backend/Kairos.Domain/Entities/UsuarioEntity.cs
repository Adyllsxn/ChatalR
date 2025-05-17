namespace Kairos.Domain.Entities;
public sealed class UsuarioEntity: EntityBase, IAgragateRoot
{
    public NomeCompleto NomeCompleto { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public int PerfilID { get; private set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; private set; }
    public byte[] PasswordHash { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;

    [JsonIgnore]
    public PerfilEntity Perfil { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<EventoEntity> Eventos { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<PresencaEntity> Presencas { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<SugestaoEntity> Sugestoes { get; private set; } = null!;

    [JsonConstructor]
    public UsuarioEntity(){}
    public UsuarioEntity(int id, string nome, string sobreNome, string email, int perfilID, DateTime dataCadastro)
    {
        DomainValidationException.When(id <= 0 , "ID deve ser maior que zero.");
        Id = id;
        ValidationDomain(nome, sobreNome, email, perfilID, dataCadastro);
    }
    public UsuarioEntity( string nome, string sobreNome, string email, int perfilID, DateTime dataCadastro)
    {
        ValidationDomain(nome, sobreNome, email, perfilID, dataCadastro);
    }

    public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
    public void SetStatus(bool isActive)
    {
        IsActive = isActive;
    }
    public void ValidationDomain( string nome, string sobreNome, string email, int perfilID, DateTime dataCadastro)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(email), "Email é obrigatório.");
        DomainValidationException.When(email.Length > 250, "Email deve ter no máximo 250 caracteres.");

        DomainValidationException.When(perfilID <= 0 , "ID deve ser maior que zero.");

        NomeCompleto = new NomeCompleto(nome, sobreNome);
        Email = email;
        PerfilID = perfilID;
        DataCadastro = dataCadastro;
        IsActive = true;
    }
}
