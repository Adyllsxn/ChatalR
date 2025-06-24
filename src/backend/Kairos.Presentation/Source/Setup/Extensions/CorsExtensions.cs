namespace Kairos.Presentation.Source.Setup.Extensions;
public static class CorsExtensions
{
    #region AddCorsExtensions
        public static void AddCorsExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(x => x.AddPolicy(
                UrlConfiguartion.CorsPolicyNames,
                policy => policy
                    .WithOrigins(UrlConfiguartion.FrontendUrl)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
            ));
        }
    #endregion

    #region UseCorsExtensions
        public static void UseCorsExtensions(this WebApplication app)
        {
            app.UseCors(UrlConfiguartion.CorsPolicyNames);
        }
    #endregion
}