namespace Kairos.Application.Abstractions.Response;
public record TipoEventoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
}
