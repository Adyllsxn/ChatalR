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

        #region </Evento>
            services.AddScoped<CreateEventoHandler>();
            services.AddScoped<DeleteEventoHandler>();
            services.AddScoped<GetFileEventoHandler>();
            services.AddScoped<GetEventosHandler>();
            services.AddScoped<GetEventoByIdHandler>();
            services.AddScoped<SearchEventoHandler>();
            services.AddScoped<UpdateEventoHandler>();
            services.AddScoped<UpdateEventoStatusHandler>();
        #endregion

        #region </Usuario>
            services.AddScoped<CreateUsuarioHandler>();
            services.AddScoped<DeleteUsuarioHandler>();
            services.AddScoped<GetUsuariosHandler>();
            services.AddScoped<GetUsuarioByIdHandler>();
            services.AddScoped<SearchUsuarioHandler>();
            services.AddScoped<UpdateUsuarioHandler>();
            services.AddScoped<ExistUsuarioHandler>();
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
