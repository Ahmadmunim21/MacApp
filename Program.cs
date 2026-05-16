var builder = WebApplication.CreateBuilder(args);

// 1. Tambah servis untuk Controller dan Views
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 2. Tetapkan laluan utama ke HomeController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
