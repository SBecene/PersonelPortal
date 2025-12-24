using Microsoft.EntityFrameworkCore;
using PersonelPortal.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabaný Baðlantý Ayarý (PostgreSQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString, npgsqlOptions => {
        // Baðlantý kopmalarýna karþý otomatik tekrar deneme ekledik
        npgsqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    }));

// 2. MVC Servislerini Ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. Veritabaný Tablolarýný Otomatik Oluþturma (Migration Alternatifi)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        // Tablolar yoksa Render üzerinde otomatik oluþturur
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Veritabaný oluþturulurken hata: " + ex.Message);
    }
}

// 4. HTTP Ýstek Kanalý Ayarlarý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Giris}/{action=Index}/{id?}");

app.Run();