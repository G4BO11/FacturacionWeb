using FacturacionWeb.DTO;
using FacturacionWeb.Models;
using FacturacionWeb.Repository;
using FacturacionWeb.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Repository
builder.Services.AddScoped<IRepository<Producto>, ProductoRepository>();
builder.Services.AddScoped<IRepository<Factura>, FacturaRepository>();
builder.Services.AddScoped<IRepository<DetalleFactura>, DetalleFacturaRepository>();
// Services
builder.Services.AddScoped<ICommonService<ProductoDto, ProductoInsertDto>, ProductoService>();
builder.Services.AddScoped<ICommonService<FacturaDto, FacturaInsertDto>, FacturaService>();

//Entity Framework Injeccion
builder.Services.AddDbContext<FacturacionWebContext>(options =>

{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
