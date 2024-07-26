using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using VVCDotNetAPILogin.API.Models;
using VVCDotNetAPILogin.API.Data;

// https://learn.microsoft.com/pt-br/aspnet/core/security/cors?view=aspnetcore-8.0
// var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; // Configurando o CORS com política nomeada e middleware.

var builder = WebApplication.CreateBuilder(args);

/*
//---Configurar-CORS------------------
// https://learn.microsoft.com/pt-br/aspnet/core/security/cors?view=aspnetcore-8.0
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
//---Configurar-CORS------------------
*/


//var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
            
builder.Services.AddDbContext<AppDbContext>(
    //options => options.UserSqlServer("Server=127.0.0.1;Port=3306;Database=dbvvclogin;Uid=root;Pwd=senharoot;") 
    options => options.UseMySQL("Server=127.0.0.1;Port=3306;Database=dbvvclogin;Uid=root;Pwd=senharoot;")
    //options => options.UseMySql(connection)
);



builder.Services.AddAuthentication(); // Quem é.
builder.Services.AddAuthorization(); // Quais permições tem.

builder.Services 
.AddIdentityApiEndpoints<User>()
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Roda o Swagger penas em desenvolvimento.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//---Configurar-CORS------------------
//app.UseCors("AllowAllOrigins");
//---Configurar-CORS------------------


//app.MapSwagger().RequireAuthorization();
app.MapGet("/", ()=>" Hello World. Projeto DotNet API com login de usuário, usando o Identity API.");
    // Retorna codigo 200

app.MapGet("/logado", ()=>"Você está logado.").RequireAuthorization();
    // Retorna codigo 200 se estiver logado.

app.MapPost("/logout", 
    async (SignInManager<User> signInManager, [FromBody] object empty) => {
        await signInManager.SignOutAsync();
        return Results.Ok(); 
        // Retorna codigo 200
    });


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