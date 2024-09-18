using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using VVCDotNetAPILogin.API.Models;
using VVCDotNetAPILogin.API.Data;

// https://learn.microsoft.com/pt-br/aspnet/core/security/cors?view=aspnetcore-8.0
// Liberar URLs Expecificas
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; // Configurando o CORS com política nomeada e middleware.


var builder = WebApplication.CreateBuilder(args);


# region Configurar-CORS
    // https://learn.microsoft.com/pt-br/aspnet/core/security/cors?view=aspnetcore-8.0

    builder.Services.AddCors(options =>
    {

        // Liberar URLs Expecificas
        options.AddPolicy(name: MyAllowSpecificOrigins,
            policy  =>
            {
                policy.WithOrigins("http://localhost","http://localhost:3000","https://vvcestudio.com.br","http://vvcestudio.com.br")
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
            });
        
        /*
        // Liberar todas as urls
        options.AddPolicy("AllowAllOrigins",
            builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        */

        // Política padrão e middleware.
        // options.AddDefaultPolicy(
    });
# endregion


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
app.UseCors(MyAllowSpecificOrigins); // Liberar URLs Expecificas
//app.UseCors("AllowAllOrigins"); // Liberar todas as urls
//---Configurar-CORS------------------


//app.MapSwagger().RequireAuthorization();

app.MapGet("/apilogin/", ()=>" Hello World! Projeto DotNet API com login de usuário, usando o Identity API.")
    .RequireCors(MyAllowSpecificOrigins);
    // Retorna codigo 200

app.MapGet("/apilogin/logado", ()=>"Você está logado.")
    .RequireAuthorization().RequireCors(MyAllowSpecificOrigins);
    // Retorna codigo 200 se estiver logado.

app.MapPost("/apilogin/logout", 
    async (SignInManager<User> signInManager, [FromBody] object empty) => {
        await signInManager.SignOutAsync();
        return Results.Ok(); 
        // Retorna codigo 200
    }).RequireCors(MyAllowSpecificOrigins);

//app.MapControllers().RequireCors(MyAllowSpecificOrigins);
// app.MapIdentityApi<User>().RequireCors(MyAllowSpecificOrigins);

app.MapGroup("/apilogin").MapIdentityApi<User>().RequireCors(MyAllowSpecificOrigins);

app.Run();