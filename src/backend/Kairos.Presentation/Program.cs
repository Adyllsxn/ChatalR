var builder = WebApplication.CreateBuilder(args);
    builder.AddBuildPipelines();

var app = builder.Build();

    var cultureInfo = new CultureInfo("en-US");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

    app.UseAppPipelines();
    app.Run();