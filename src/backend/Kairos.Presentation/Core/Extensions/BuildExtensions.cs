namespace Kairos.Presentation.Core.Extensions;
public static class BuildExtensions
{
    public static void AddBuildExtensions(this WebApplicationBuilder builder)
    {
        builder.AddControllersExtensions();
        builder.AddSwaggerExtensions();
        builder.AddJwtBearerExtensions(builder.Configuration);
        builder.AddCorsExtensions();
        builder.AddExternalLayersExtensions();
    }
}
