using Microsoft.AspNetCore.SpaServices.AngularCli;
using AngularExampleApp.Core.Services;
using AngularExampleApp.Core;
using AngularExampleApp.Core.Models;
using AngularExampleApp.Core.Models.Mappings;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.Configure<UserDbConfiguration>(builder.Configuration.GetSection(nameof(UserDbConfiguration)));
services.AddTransient<IService<UserMapping>, UserService>();
services.AddTransient<IService<UserTypeMapping>, UserTypeService>();
services.AddSingleton<IDbClient<User>, UserDbClient>();
services.AddSingleton<IDbClient<UserType>, UserTypeDbClient>();

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