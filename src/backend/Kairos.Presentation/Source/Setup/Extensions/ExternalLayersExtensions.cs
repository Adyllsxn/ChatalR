namespace Kairos.Presentation.Source.Setup.Extensions;
public static class ExternalLayersExtensions
{
    public static void AddExternalLayersExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructureDI(builder.Configuration);
        builder.Services.AddApplicationDI();
    }
}
