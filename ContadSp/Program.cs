using ContadSp.Data;
using ContadSp.Modelos;
using ContadSp.Repositorios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders; // administracion de archivos
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.IO; // entrada y salida

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IRepositorio<Modelo_ABM_Categoria>, Repositorio<Modelo_ABM_Categoria>>();
builder.Services.AddScoped<IRepositorio<Modelo_Articulos>, Repositorio<Modelo_Articulos>>();
builder.Services.AddScoped<IRepositorio<Modelo_Pedido>, Repositorio<Modelo_Pedido>>();
builder.Services.AddScoped<IRepositorio<Modelo_Detalle_Pedido>, Repositorio<Modelo_Detalle_Pedido>>();
builder.Services.AddScoped<IRepositorio<Modelo_Unidad_Medida>, Repositorio<Modelo_Unidad_Medida>>();
builder.Services.AddScoped<IRepositorio<Modelo_Destino>, Repositorio<Modelo_Destino>>();
builder.Services.AddScoped<ContadSpContext>();

builder.Services.AddHttpClient(); // Agrega esta l�nea
builder.Services.AddDbContext<ContadSpContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 36))
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

// lectura del directorio de fotos
app.UseStaticFiles(new StaticFileOptions
{
    //FileProvider = new PhysicalFileProvider(
    //    Path.Combine("d:\\fotos1")),
    //RequestPath = "/fotos1"
});

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();