namespace Kairos.Presentation.Core.Extensions;
public static class AppExtensions
{
    public static void UseAppExtensions(this WebApplication app)
    {
        app.UseCorsExtensions();
        app.UseSweggerExtensions();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
