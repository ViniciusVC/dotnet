using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.Security.Claims; // < -- para incluir informações no Tokem.

using VVCDotNetAPITokensJWT.Models;
using VVCDotNetAPITokensJWT.Services;

namespace VVCDotNetAPITokensJWT.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    // PrevisaoTempo
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

   
    private readonly ILogger<ApiController> _logger; // PrevisaoTempo
    private readonly TokenService _tokenService; 
    private readonly JwtSettings _jwtSettings;

    /*
    // PrevisaoTempo
    public ApiController(ILogger<ApiController> logger)
    {
        _logger = logger;
    }
    */


    public ApiController(TokenService tokenService, IOptions<JwtSettings> jwtSettings, ILogger<ApiController> logger)
    {
        _logger = logger;
        _tokenService = tokenService;
        _jwtSettings = jwtSettings.Value;
    }



    [HttpGet]
    public ActionResult GetHome()
    {
        Console.WriteLine("[Metodo Get] /. API funcionando.");
        return Ok("API funcionando.");  // Retorno da requisião.
    }


    [HttpGet("Teste")]
    public ActionResult Test()
    {
        Console.WriteLine("[Metodo Get] /. API funcionando.");
        return Ok("API funcionando.");  // Retorno da requisião.
    }

    [HttpGet("GetPrevisaoTempo")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("GeraTokenJWT/{senha}/{email}/")]
    public IActionResult GetToken( string senha, string email)
    {
        var user = new User(
            1,
            email,
            senha,
            new[] { "perfil", "adm" }
        );

        var token = _tokenService.Generate(user, _jwtSettings.SecretKey);
        return Ok(token);
    }

    [HttpGet("GeraTokenJWT/default")]
    public IActionResult GetToken()
    {
        var user = new User(
            1,
            "teste@teste.com",
            "123",
            new[] { "perfil", "visit" }
        );

        var token = _tokenService.Generate(user, _jwtSettings.SecretKey);
        return Ok(token);
    }


    [HttpGet("Protected/default")]
    [Authorize]
    public IActionResult GetProtectedData()
    {
        return Ok("Acessou o endpoint protegido! Tokem confirmado.");
    }


    [HttpGet("Protected/user")]
    [Authorize]
    public IActionResult GetProtectedUser()
    {

        // Acessar as claims do usuário autenticado
        var userId = User.FindFirst("sub")?.Value; // "sub" é a claim padrão para o ID do usuário
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var roles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

        return Ok(new
        {
            UserId = userId,
            Email = email,
            Roles = roles
        });
    }

}

