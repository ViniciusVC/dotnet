using VVCDotNetTokensJWT.Services;
using VVCDotNetTokensJWT.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenService>();

//WebApplication
var app = builder.Build();

//app.MapPost("/", (User user, TokenService tokenService) 
//    => tokenService.Generate(user));

app.MapGet("/", (TokenService service)
    => service.Generate(new User(
        1, 
        "teste@teste.com", 
        "123", 
        new[]
        {
            "student","premium"
        }
    ))
);

app.Run();
