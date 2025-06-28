namespace Kairos.Infrastructure.Abstractions.DI;
public static class InfrastructureDI
{
    public static void AddInfrastructureDI (this IServiceCollection services, IConfiguration configuration)
    {
        #region </Repositories>
            services.AddScoped<IAuthIdentity, AuthIdentity>();
        _ = services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDashboardRepository, DashBoardRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IPresencaRepository, PresencaRepository>();
            services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
        #endregion

        #region </DbConnection>
            var connectionDb = configuration.GetConnectionString(ConnectionDbStringContext.ConnectionDbSqlServer);

            services.AddDbContext<AppDbContext>(opt =>{
                opt.UseSqlServer(connectionDb,
                migration => migration.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });
        #endregion
    }
}