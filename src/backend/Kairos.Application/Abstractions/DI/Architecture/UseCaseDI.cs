namespace Kairos.Application.Abstractions.DI.Architecture;
public static class UseCaseDI
{
    public static void AddUseCaseDI (this IServiceCollection services)
    {
        #region </Dashboard>
            services.AddScoped<GetDashboardHandler>();
        #endregion

        #region </Perfil>
            services.AddScoped<GetPerfilByIdHandler>();
            services.AddScoped<GetPerfilsHandler>();
            services.AddScoped<SearchPerfilHandler>();
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
