namespace Kairos.Presentation.Core.Extensions.Architecture;
public static class CorsExtensions
{
    public static void AddCorsExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors( x => x.AddPolicy(
            UrlConfiguartion.CorsPolicyNames,
            policy => policy.
                    WithOrigins(UrlConfiguartion.BackendUrl, UrlConfiguartion.FrontendUrl).
                    WithHeaders().
                    AllowAnyMethod().
                    AllowCredentials()
        ));
    }

    public static void UseCorsExtensions(this WebApplication app)
    {
        app.UseCors(UrlConfiguartion.CorsPolicyNames);
    }
}