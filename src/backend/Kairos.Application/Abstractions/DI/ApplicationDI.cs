namespace Kairos.Application.Abstractions.DI;
public static class ApplicationDI
{
    public static void AddApplicationDI (this IServiceCollection services)
    {
        services.AddServiceDI();
        services.AddUseCaseDI();
    }
}
