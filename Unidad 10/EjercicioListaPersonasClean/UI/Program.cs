using Domain.Interfaces;
using Domain.Repositories;
using Domain.UseCase;
using CompositionRoot;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCompositionRoot(builder.Configuration);
builder.Services.AddScoped<IGetListaPersonasUseCase, DefaultGetListaPersonasUseCase>();
builder.Services.AddControllersWithViews();
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
