using Domain.Interfaces;
using Domain.Repositories;
using Domain.UseCases;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registramos los servicios para Clean Architecture
builder.Services.AddSingleton<IMisionesRepository, MisionesRepository>();
builder.Services.AddSingleton<IGetMisionesUseCase, DefaultGetMisionesUC>();


var app = builder.Build();

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

app.Run();

