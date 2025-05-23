namespace Kairos.Presentation.Core.Extensions.Architecture;
public static class JwtBearerExtensions
{
    public static void AddJwtBearerExtensions(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        ).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = configuration["jwt:issuer"],
                ValidAudience = configuration["jwt:audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:secretKey"] ?? throw new InvalidOperationException("JWT secret key is not configured."))),
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}