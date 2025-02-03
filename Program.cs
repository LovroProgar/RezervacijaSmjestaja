using Microsoft.EntityFrameworkCore;
using RezervacijaSmjestaja.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// 📌 Postavljanje baze podataka
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 📌 Dodavanje servisa za kontrolere i prikaze
builder.Services.AddControllersWithViews();

// 📌 Omogućavanje sesije
builder.Services.AddSession();

// 📌 Konfiguracija autentifikacije putem kolačića (cookie-based authentication)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Preusmjerava neulogirane korisnike na login
        options.AccessDeniedPath = "/Account/Login"; // Ako nemaju dozvolu
    });

var app = builder.Build();

// 📌 Automatska migracija baze prilikom pokretanja aplikacije
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// 📌 Omogućavanje autentifikacije i sesija
app.UseAuthentication(); // Dodano!
app.UseSession();
app.UseAuthorization();

// 📌 Postavljanje rute – ako nije prijavljen, ide na Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
