using Microsoft.EntityFrameworkCore;
using VVCDotNetAPILogin.API.Models;
using VVCDotNetAPILogin.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
            
builder.Services.AddDbContext<AppDbContext>(
    //options => options.UserSqlServer("Server=127.0.0.1;Port=3306;Database=dbvvclogin;Uid=root;Pwd=senharoot;") 
    options => options.UseMySQL("Server=127.0.0.1;Port=3306;Database=dbvvclogin;Uid=root;Pwd=senharoot;")
    //options => options.UseMySql(connection)
);

builder.Services.AddAuthentication(); // Quem é.
builder.Services.AddAuthorization(); // Quais permições tem.

builder.Services //IServiceCollection
.AddIdentityApiEndpoints<User>()
.AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", ()=>"Hello World");

app.MapIdentityApi<User>();

/*
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
.WithName("GetWeatherForecast")
.WithOpenApi();
*/

app.Run();

/*
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
*/