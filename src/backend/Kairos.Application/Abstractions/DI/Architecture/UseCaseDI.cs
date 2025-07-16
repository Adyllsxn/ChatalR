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

        #region </Presença>
            services.AddScoped<CreatePresencaHandler>();
            services.AddScoped<DeletePresencaHandler>();
            services.AddScoped<GetPresencaHandler>();
            services.AddScoped<GetPresencaByIdHandler>();
            services.AddScoped<SearchPresencaHandler>();
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
            services.AddScoped<GetEventosReijetadoHandler>();
            services.AddScoped<GetEventosAprovadoHandler>();
            services.AddScoped<GetEventosPendenteHandler>();
        #endregion

        #region </Usuario>
            services.AddScoped<CreateUsuarioHandler>();
            services.AddScoped<DeleteUsuarioHandler>();
            services.AddScoped<GetUsuariosHandler>();
            services.AddScoped<GetUsuarioByIdHandler>();
            services.AddScoped<SearchUsuarioHandler>();
            services.AddScoped<ExistUsuarioHandler>();
            services.AddScoped<UsuarioStatusHandler>();
            services.AddScoped<UpdateUsuarioHandler>();
            services.AddScoped<UpdateUsuarioFotoHandler>();
            services.AddScoped<GetUsuarioFotoHandler>();
        #endregion

        #region </TipoEventos>
            services.AddScoped<CreateTipoEventoHandler>();
            services.AddScoped<DeleteTipoEventoHandler>();
            services.AddScoped<GetTipoEventosHandler>();
            services.AddScoped<GetTipoEventoByIdHandler>();
            services.AddScoped<SearchTipoEventoHandler>();
            services.AddScoped<UpdateTipoEventoHandler>();
        #endregion

        #region </Blog>
            services.AddScoped<CreateBlogHandler>();
            services.AddScoped<DeleteBlogHandler>();
            services.AddScoped<GetBlogsHandler>();
            services.AddScoped<GetBlogByIdHandler>();
            services.AddScoped<SearchBlogHandler>();
            services.AddScoped<UpdateBlogHandler>();
            services.AddScoped<ArchiveBlogHandler>();
            services.AddScoped<GetFileBlogHandler>();
            services.AddScoped<GetPublishBlogHandler>();
            services.AddScoped<PublishBlogHandler>();
        #endregion
    }
}
