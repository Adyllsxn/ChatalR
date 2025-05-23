namespace Kairos.Application.Abstractions.DI.Architecture;
public static class UseCaseDI
{
    public static void AddUseCaseDI (this IServiceCollection services)
    {
        #region </TipoEventos>
            services.AddScoped<GetTipoEventosHandler>();
        #endregion
    }
}
