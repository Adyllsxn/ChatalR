namespace Kairos.Infrastructure.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public virtual DbSet<PerfilEntity> Perfils { get; set; } = null!;
    public virtual DbSet<EventoEntity> Eventos { get; set; } = null!;
    public virtual DbSet<UsuarioEntity> Usuarios { get; set; } = null!;
    public virtual DbSet<PresencaEntity> Presencas { get; set; } = null!;
    public virtual DbSet<SugestaoEntity> Sugestoes { get; set; } = null!;
    public virtual DbSet<TipoEventoEntity> TipoEventos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureDI).Assembly);
}
