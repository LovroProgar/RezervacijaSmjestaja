using Microsoft.EntityFrameworkCore;
using RezervacijaSmjestaja.Data;

var builder = WebApplication.CreateBuilder(args);

// Dodaj DbContext (povezuje aplikaciju s bazom podataka)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dodaj MVC
builder.Services.AddControllersWithViews();

// Dodaj podršku za sesije
builder.Services.AddSession();

var app = builder.Build();

// Automatsko pokretanje migracija prilikom pokretanja aplikacije
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate(); // Pokreće migracije ako su potrebne
}

// Konfiguracija middleware-a
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession(); // Omogući sesije

app.UseAuthorization();

// Postavi defaultnu rutu
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();
