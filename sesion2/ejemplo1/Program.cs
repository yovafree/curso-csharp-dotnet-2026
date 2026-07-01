var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


var names = new[]
{
    "Juan", "Pedro", "Maria", "Jose", "Luis", "Ana", "Carmen", "Jorge", "Lucia", "Miguel"
};

app.MapGet("/names", () =>
{
    var nameList = Enumerable.Range(1,5)
    .Select(index => names[Random.Shared.Next(names.Length)])
    .ToList();

    return nameList;
})
.WithName("GetNames");

app.MapGet("/saludo/{nombre}", (string nombre) =>
{
    return $"Hola, {nombre} bienvenido al curso de C# y .NET 10!";
});

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
