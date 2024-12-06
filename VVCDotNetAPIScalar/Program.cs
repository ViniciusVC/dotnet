using Scalar.AspNetCore; // importar Scalar (Substituto ao Swagger)
using Microsoft.AspNetCore.Authentication.JwtBearer; // Token
using Microsoft.IdentityModel.Tokens; // Token
//using System.Reflection;
using System.Text;
using VVCDotNetAPITokensJWT; 
using VVCDotNetAPITokensJWT.Services;


var builder = WebApplication.CreateBuilder(args);

 // Add services to the container.
 builder.Services.AddControllers();
 builder.Services.AddSingleton<TokenService>(); // < ---Incluido para Token JWT

 builder.Services.AddEndpointsApiExplorer(); // Mapear endpoints para OpenAPI


builder.Services.AddOpenApi(); // Adiciona suporte ao OpenAPI

//builder.Services.AddScalarApiReference(); // Adiciona suporte ao Scalar


// Registrar a configuracao JWT
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("jwt"));  // < ---Incluido para Token JWT


// -Configurar-a-autenticacao-JWT---------------------\
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
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey))
    };
});
// -Configurar-a-autenticacao-JWT---------------------/

//builder.Services.AddSwaggerGen();

/*
// -Configurar-a-Swegger---------------------------\
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "APiGodModelo",
                        Description = "Endpoint que disponibiliza recursos sobre as equipes de campo.",
                        Version = "v1",
                        TermsOfService = null,
                        Contact = new OpenApiContact
                        {
                            Email = "teccom_sustentacao@energisa.com.br",
                            Name = "TECCOM Sustentação"
                        },
                        License = new OpenApiLicense
                        {
                            // Optional Example
                            // Name = "Proprietary",
                            // Url = new Uri("https://someURLToLicenseInfo.com")
                        }
                    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    //================================================================= Incluido Authorization no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Autorizacao header usando Bearer. <br> 
                      Digite 'Bearer' [espaco] e entao o token abaixo.<br>
                      Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                new List<string>()
            }
        });


    options.IncludeXmlComments(xmlPath);
});
//=============================================================/
*/


var app = builder.Build();


/*
//------------------------------------------
app.MapScalarApiReference(options =>
{
    // Basic
    options
        .WithPreferredScheme("Basic") // Security scheme name from the OpenAPI document
        .WithHttpBasicAuthentication(basic =>
        {
            basic.Username = "your-username";
            basic.Password = "your-password";
        });

    // Bearer
    options
        .WithPreferredScheme("Bearer") // Security scheme name from the OpenAPI document
        .WithHttpBearerAuthentication(bearer =>
        {
            bearer.Token = "your-bearer-token";
        });
});
//-------------------------------------------
*/


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseDeveloperExceptionPage(); // < -- ?

    // Abrira o scalar/v1 em desenvolvimento.
    app.MapOpenApi();
    app.MapScalarApiReference(); 

}

//app.UseHttpsRedirection(); // Configurar o pipeline HTTP
app.UseAuthorization();

app.MapControllers(); // Usar Controllers para gerar os endpopints.
//app.MapGet("/", () => "Hello world!");

app.Run();

