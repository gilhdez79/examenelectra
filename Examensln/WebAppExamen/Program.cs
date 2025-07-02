using WebAppExamen.Services;
using WebAppExamen.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
///builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddScoped<IAlumnosServices, AlumnoServices>();
builder.Services.AddHttpClient(
    "ApiEscuela",
    client =>
    {
        // Set the base address of the named client.
        client.BaseAddress = new Uri(builder.Configuration["ServiceUrl"]);

    });

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
