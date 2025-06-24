namespace Kairos.Presentation.Source.Setup.Extensions;
public static class SwaggerExtensions
{   
    #region AddSwaggerExtensions
        public static void AddSwaggerExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(
                c =>
                {
                    #region SwaggerDoc
                        c.SwaggerDoc("v1", new OpenApiInfo{
                            Title = "Kairos.API",
                            Version = "v1",
                            Description = "Sistema para facilitar a organização de cultos e eventos, com gestão de participantes, presença e envio de lembretes."
                        });
                    #endregion

                    #region SecurityDefinition
                        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
                            Name = "Authorization",
                            Type = SecuritySchemeType.ApiKey,
                            BearerFormat = "JWT",
                            In = ParameterLocation.Header,
                            Description = "Insira o token para se autenticar"
                        });
                    #endregion

                    #region SecurityRequirement
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
    #endregion
    
    #region UseSweggerExtensions
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
    #endregion
}