using Microsoft.AspNetCore.SpaServices.AngularCli;
using AngularExampleApp.Core.Services;
using AngularExampleApp.Core;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.Configure<UserDbConfiguration>(builder.Configuration.GetSection(nameof(UserDbConfiguration)));
services.AddTransient<IUserService, UserService>();
services.AddSingleton<IDbClient, DbClient>();

services.AddControllers();
services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "Views/dist";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseSpaStaticFiles();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "Views";

    if (app.Environment.IsDevelopment())
    {
        spa.UseAngularCliServer(npmScript: "start");
    }
});

app.Run();