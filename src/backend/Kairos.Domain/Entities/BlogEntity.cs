namespace Kairos.Domain.Entities;

public class BlogEntity : EntityBase, IAggragateRoot
{
    public int AutorID { get; private set; }
    public string Titulo { get; private set; } = null!;
    public string Conteudo { get; private set; } = null!;
    public DateTime DataPublicacao { get; private set; }
    public EStatusPostagem Status { get; private set; } = EStatusPostagem.Rascunho;

    [JsonIgnore]
    public UsuarioEntity Autor { get; private set; } = null!;

    [JsonConstructor]
    public BlogEntity() {}

    public BlogEntity(int id, int autorID, string titulo, string conteudo, DateTime dataPublicacao)
    {
        DomainValidationException.When(id <= 0, "ID deve ser maior que zero.");
        Id = id;
        Validar(autorID, titulo, conteudo, dataPublicacao);
    }

    public BlogEntity(int autorID, string titulo, string conteudo, DateTime dataPublicacao)
    {
        Validar(autorID, titulo, conteudo, dataPublicacao);
    }

    private void Validar(int autorID, string titulo, string conteudo, DateTime dataPublicacao)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(titulo), "Título é obrigatório.");
        DomainValidationException.When(titulo.Length < 3, "Título deve ter no mínimo 3 caracteres.");
        DomainValidationException.When(string.IsNullOrWhiteSpace(conteudo), "Conteúdo é obrigatório.");
        DomainValidationException.When(conteudo.Length < 10, "Conteúdo deve ter no mínimo 10 caracteres.");
        DomainValidationException.When(autorID <= 0, "ID do autor deve ser maior que zero.");

        AutorID = autorID;
        Titulo = titulo;
        Conteudo = conteudo;
        DataPublicacao = dataPublicacao;
        Status = EStatusPostagem.Rascunho;
    }

    public void AtualizarConteudo(string novoTitulo, string novoConteudo)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(novoTitulo), "Título é obrigatório.");
        DomainValidationException.When(novoTitulo.Length < 3, "Título deve ter no mínimo 3 caracteres.");
        DomainValidationException.When(string.IsNullOrWhiteSpace(novoConteudo), "Conteúdo é obrigatório.");
        DomainValidationException.When(novoConteudo.Length < 10, "Conteúdo deve ter no mínimo 10 caracteres.");
        Titulo = novoTitulo;
        Conteudo = novoConteudo;
    }

    public void Publicar()
    {
        DomainValidationException.When(Status != EStatusPostagem.Rascunho,
            "Apenas posts em rascunho podem ser publicados.");
        Status = EStatusPostagem.Publicado;
    }
}
