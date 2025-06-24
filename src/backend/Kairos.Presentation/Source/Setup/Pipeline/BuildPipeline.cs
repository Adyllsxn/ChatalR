namespace Kairos.Presentation.Source.Setup.Pipeline;
public static class BuildPipeline
{
    public static void AddBuildPipelines(this WebApplicationBuilder builder)
    {
        builder.AddControllersExtensions();
        builder.AddSwaggerExtensions();
        builder.AddJwtBearerExtensions(builder.Configuration);
        builder.AddCorsExtensions();
        builder.AddExternalLayersExtensions();
    }
}
