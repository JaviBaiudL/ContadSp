using ContadSp.Data;
using ContadSp.Modelos;
using ContadSp.Repositorios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IRepositorio<Modelo_ABM_Categoria>, Repositorio<Modelo_ABM_Categoria>>();
builder.Services.AddScoped<IRepositorio<Modelo_Articulos>, Repositorio<Modelo_Articulos>>();
builder.Services.AddScoped<IRepositorio<Modelo_Pedido>, Repositorio<Modelo_Pedido>>();
builder.Services.AddScoped<IRepositorio<Modelo_Detalle_Pedido>, Repositorio<Modelo_Detalle_Pedido>>();
builder.Services.AddScoped<IRepositorio<Modelo_Unidad_Medida>, Repositorio<Modelo_Unidad_Medida>>();
builder.Services.AddScoped<ContadSpContext>();

builder.Services.AddHttpClient(); // Agrega esta línea
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

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();