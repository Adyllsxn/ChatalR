namespace Kairos.Application.Abstractions.DI.Architecture;
public static class UseCaseDI
{
    public static void AddUseCaseDI (this IServiceCollection services)
    {
        #region </Dashboard>
            services.AddScoped<GetDashboardHandler>();
        #endregion

        #region </TipoEventos>
            services.AddScoped<CreateTipoEventoHandler>();
            services.AddScoped<DeleteTipoEventoHandler>();
            services.AddScoped<GetTipoEventosHandler>();
            services.AddScoped<GetTipoEventoByIdHandler>();
            services.AddScoped<SearchTipoEventoHandler>();
            services.AddScoped<UpdateTipoEventoHandler>();
        #endregion
    }
}
