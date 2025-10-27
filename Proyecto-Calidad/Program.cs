using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Proyecto_Calidad.Data;
using Proyecto_Calidad.Models;
using Proyecto_Calidad.seed;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConectionSQLServer");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;

    // Configuraci�n personalizada para permitir contrase�as simples
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3; // o lo que desees
    options.Password.RequiredUniqueChars = 0;
})
    .AddEntityFrameworkStores<AppDBContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//datos iniciales
builder.Services.AddScoped<IDbInitialize, DbInitialize>();
// Configurar Identity para usar ApplicationUser
builder.Services.AddTransient<ApplicationUser>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
    try
    {
        var inicializador = services.GetRequiredService<IDbInitialize>();
        inicializador.Initialize();
    }
    catch (Exception)
    {
        throw;
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapRazorPages();

app.Run();
