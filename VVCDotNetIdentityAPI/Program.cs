//using Google.Protobuf.WellKnownTypes;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

app.MapGet("/", () => "Hello World!");

app.MapIdentityApi<User>();

app.Run();
