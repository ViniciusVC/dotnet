using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
using VVCDotNetIdentityAPI.Data;
using VVCDotNetIdentityAPI.Models;


var builder = WebApplication.CreateBuilder(args);

//var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
                              
builder.Services.AddDbContext<AppDbContext>(
    //options => options.UseMySql("Server=127.0.0.1;Port=3306;Database=dbvvclogin;Uid=root;Pwd=senharoot;")
    options => options.UseMySQL("Server=127.0.0.1;Port=3306;Database=dbvvclogin;Uid=root;Pwd=senharoot;")
    //options => options.UseMySql(connection)
);
// The type or namespace name 'AppDbContext' could not be found (are you missing a using directive or an assembly. 

builder.Services.AddAuthentication(); // Quem é.
builder.Services.AddAuthorization(); // Quais permições tem.

// 'IServiceCollection' não contém uma definição para 'AppAuthentication' e nenhum método de extensão acessível 'AppAuthentication' aceitando um primeiro argumento do tipo 'IServiceCollection' foi encontrado (está faltando uma diretiva using ou uma referência de assembly?)

builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

app.MapGet("/", () => " Ok. Projeto VVCDotNetIdentity.");
app.MapGet("/logado", ()=>" Ok. Logado no Projeto VVCDotNetIdentity.").RequireAuthorization();
app.MapPost("/logout", 
    async (SignInManager<User> signInManager, [FromBody] object empty) => {
        await signInManager.SignOutAsync();
        return Results.Ok(); // Retorna codigo 200
    });

app.MapIdentityApi<User>();

app.Run();
