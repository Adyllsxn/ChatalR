namespace Kairos.Domain.Entities;
public sealed class TipoEventoEntity: EntityBase, IAggragateRoot
{
    public string Nome { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<EventoEntity> Eventos { get; private set; } = null!;

    [JsonConstructor]
    public TipoEventoEntity(){}

    public TipoEventoEntity(int id, string nome)
    {   
        DomainValidationException.When(id <= 0 , "ID deve ser maior que zero.");
        Id = id;
        ValidationDomain(nome);
    }
    public TipoEventoEntity(string nome)
    {
        ValidationDomain(nome);
    }
    public void ValidationDomain(string nome)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(nome), "Nome é obrigatório.");
        DomainValidationException.When(nome.Length > 50, "Nome deve ter no máximo 50 caracteres.");

        Nome =nome;
    }
}
