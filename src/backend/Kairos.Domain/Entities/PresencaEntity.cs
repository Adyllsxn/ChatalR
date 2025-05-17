namespace Kairos.Domain.Entities;
public sealed class PresencaEntity: EntityBase, IAgragateRoot
{
    public int UsuarioID { get; private set; }
    public int EventoID { get; private set; }
    public DateTime DataHoraCheckin { get; private set; }

    [JsonIgnore]
    public UsuarioEntity Usuario { get; private set; } = null!;

    [JsonIgnore]
    public EventoEntity Evento { get; private set; } = null!;

    [JsonConstructor]
    public PresencaEntity(){}

    public PresencaEntity(int id, int usuarioID, int eventoID, DateTime dataHoraCheckin)
    {
        DomainValidationException.When(id <= 0 , "ID deve ser maior que zero.");
        Id = id;
        ValidationDomain( usuarioID, eventoID, dataHoraCheckin);
    }
    public PresencaEntity(int usuarioID, int eventoID, DateTime dataHoraCheckin)
    {
        ValidationDomain( usuarioID, eventoID, dataHoraCheckin);
    }
    public void ValidationDomain(int usuarioID, int eventoID, DateTime dataHoraCheckin)
    {
        DomainValidationException.When(usuarioID <= 0 , "ID do Usuário deve ser maior que zero.");
        DomainValidationException.When(eventoID <= 0 , "ID do Evento deve ser maior que zero.");

        UsuarioID = usuarioID;
        EventoID = eventoID;
        DataHoraCheckin = dataHoraCheckin;
    }
}
