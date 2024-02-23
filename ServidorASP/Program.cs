using Microsoft.EntityFrameworkCore;
using ServidorASP.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Db Conexion
try
{
    var variable = Environment.GetEnvironmentVariable("ConexionDb");
    builder.Services.AddDbContext<RailwayContext>(options => options.UseNpgsql(variable));
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Errores
app.UseStatusCodePagesWithReExecute("/Error/Index", "?statusCode={0}");

app.MapWhen(
    context => context.Request.Host.Host.Equals("estuardodev.com", StringComparison.OrdinalIgnoreCase),
    ConfigureEstuardoDev);

app.MapWhen(
    context => context.Request.Host.Host.Equals("estuardo.dev", StringComparison.OrdinalIgnoreCase),
    ConfigureEstuardoDotDev);

app.MapWhen(
    context => context.Request.Host.Host.Equals("janoabonce.stream", StringComparison.OrdinalIgnoreCase),
    ConfigureJanoAbonce);

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

void ConfigureEstuardoDev(IApplicationBuilder estuardoDevApp) =>
    estuardoDevApp.UseRouting().UseEndpoints(e => e.MapControllerRoute("estuardodev", "{controller=Blog}/{action=Index}/{id?}"));

void ConfigureEstuardoDotDev(IApplicationBuilder estuardoDotDevApp)
{
    estuardoDotDevApp.UseRouting().UseEndpoints(e => e.MapControllerRoute("estuardo.dev", "{controller=Portafolio}/{action=Index}/{id?}"));
}
void ConfigureJanoAbonce(IApplicationBuilder janoAbonceApp) =>
    janoAbonceApp.UseRouting().UseEndpoints(e => e.MapControllerRoute("janoabonce.stream", "{controller=Jano}/{action=Index}/{id?}"));

app.Run();
