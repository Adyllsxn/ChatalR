namespace Kairos.Presentation.Source.Setup.Pipeline;
public static class AppPipeline
{
    public static void UseAppPipelines(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        var storagePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage");
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(storagePath),
            RequestPath = "/Storage"
        });

        app.UseSweggerExtensions();
        app.UseCorsExtensions();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}
