var builder = WebApplication.CreateBuilder(args);
    builder.AddBuildExtensions();

var app = builder.Build();
    app.UseAppExtensions();

var cultureInfo = new CultureInfo("en-US");
    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;