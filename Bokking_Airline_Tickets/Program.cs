using Microsoft.EntityFrameworkCore;
using Bokking_Airline_Tickets.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext с SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем Razor Pages
builder.Services.AddRazorPages();

// Добавляем сессии
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Создаем базу при запуске
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Важно: сначала сессии, затем авторизация
app.UseSession();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
