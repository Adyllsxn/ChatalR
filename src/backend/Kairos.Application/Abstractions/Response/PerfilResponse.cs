namespace Kairos.Application.Abstractions.Response;
public record PerfilResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
}
