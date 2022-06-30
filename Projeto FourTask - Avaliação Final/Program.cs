using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projeto_FourTask___Avaliação_Final.Areas.Identity.Data;
using Projeto_FourTask___Avaliação_Final.Models;
using Projeto_FourTask___Avaliação_Final.Repositorio;
using Projeto_FourTask___Avaliação_Final.Repositorio.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentidadeContextConnection")
    ?? throw new InvalidOperationException("Connection string 'IdentidadeContextConnection' not found.");

builder.Services.AddDbContext<IdentidadeContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IdentidadeContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Repositorios
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IEquipeRepositorio, EquipeRepositorio>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();