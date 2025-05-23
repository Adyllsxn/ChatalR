namespace Kairos.Presentation.Core.Extensions.Architecture;
public static class SwaggerExtensions
{
    public static void AddSwaggerExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(
            c =>
            {
                #region </SwaggerDoc>
                    c.SwaggerDoc("v1", new OpenApiInfo{
                        Title = "Kairos.API",
                        Version = "v1",
                        Description = ""
                    });
                #endregion

                #region </SecurityDefinition>
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Insira o token para se autenticar"
                    });
                #endregion

                #region </SecurityRequirement>
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme()
                            {
                                Reference = new OpenApiReference()
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string []{}
                        }
                    });
                #endregion
            }
        );
    }

    public static void UseSweggerExtensions(this WebApplication app)
    {
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
                c.ConfigObject.AdditionalItems["locale"] = "en";
            });
        }
    }
}