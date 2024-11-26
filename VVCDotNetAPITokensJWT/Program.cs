using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VVCDotNetAPITokensJWT;
using VVCDotNetAPITokensJWT.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<TokenService>(); // < -------Incluido para Token


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar a leitura do appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Registrar a configuração JWT
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("jwt"));


// |-Configurar-a-autenticacao-JWT---------------------|
var jwtSettings = builder.Configuration.GetSection("jwt").Get<JwtSettings>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey))
    };
});
// |-Configurar-a-autenticacao-JWT---------------------|

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Abrirá o Swagger em desenvolvimento.
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); // Configurar o pipeline HTTP
app.UseAuthorization();

app.MapControllers();

app.Run();
