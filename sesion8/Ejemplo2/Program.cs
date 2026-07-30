using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connStr = builder.Configuration
    .GetConnectionString("Default");

builder.Services.AddDbContext<LibrosDBContext>(
    options => options.UseMySQL(connStr));




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    LibrosDBContext context = scope.ServiceProvider.GetRequiredService<LibrosDBContext>();
    Console.WriteLine("Creando la base de datos si no existe...");
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
