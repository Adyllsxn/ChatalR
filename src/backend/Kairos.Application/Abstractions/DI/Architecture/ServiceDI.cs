namespace Kairos.Application.Abstractions.DI.Architecture;
public static class ServiceDI
{
    public static void AddServiceDI (this IServiceCollection services)
    {
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<ITipoEventoService, TipoEventoService>();
        services.AddScoped<IPerfilService, PerfilService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IEventoService, EventoService>();
        services.AddScoped<IPresencaService, PresencaService>();
    }
}
