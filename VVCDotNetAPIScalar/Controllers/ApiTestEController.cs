using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims; // < -- para incluir informacoes no Tokem.

using VVCDotNetAPITokensJWT.Models;
using VVCDotNetAPITokensJWT.Services;

namespace VVCDotNetAPITokensJWT.Controllers;

[ApiController]
[Route("apiTestE/[controller]")]
public class ApiTestEController : ControllerBase
{

   
    private readonly ILogger<ApiController> _logger; // PrevisaoTempo
    private readonly TokenService _tokenService; 
    private readonly JwtSettings _jwtSettings;

    
    public ApiTestEController(TokenService tokenService, IOptions<JwtSettings> jwtSettings, ILogger<ApiController> logger)
    {
        _logger = logger;
        _tokenService = tokenService;
        _jwtSettings = jwtSettings.Value;
    }

    /// <summary>
    /// Gera o Token JWT Bearer.
    /// </summary>
    /// <returns>Retorna uma string.</returns>
    [HttpGet("GetTokenTest/")]
    public IActionResult GetTokenTest()
    {
        var testeE = new TesteE(
            new[] {"EASR","EASR"},
            "EASR",
            "4fcbdefbc5264bf6bbcabe6c9bd86696",
            "supervisor",
            "1",
            "193",
            "https://localhost-Development",
            "Sigod-Development"
        );

        var token = _tokenService.GenerateTesteE(testeE, _jwtSettings.SecretKey);
        return Ok(token);
    }


    /// <summary>
    /// Testar se o Token est� ok.
    /// </summary>
    /// <returns> Retorna uma mensagem que o token foi autorizado.</returns>
    [HttpGet("Protected/defaultTestE")]
    [Authorize]
    public IActionResult GetProtectedData()
    {
        return Ok("Acessou o endpoint protegido! Tokem confirmado.");
    }


    [HttpGet("Protected/user")]
    [Authorize]
    public IActionResult GetProtectedUser()
    {

        /*
        //string[] unique_name)?.Value;

        var Usuario = TesteE.FindFirst("Usuario")?.Value;
        var ordem = TesteE.FindFirst("ordem")?.Value;
        var role = TesteE.FindFirst("role")?.Value;
        var demanda = TesteE.FindFirst("demanda")?.Value;
        var Localidade = TesteE.FindFirst("Localidade")?.Value;
        var iss = TesteE.FindFirst("Iss")?.Value;
        var aud = TesteE.FindFirst("Aud")?.Value;

        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var roles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();
        */
        
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var uniqueName = jwtToken.Claims.Where(c => c.Type == "unique_name").Select(c => c.Value).ToArray();
        var usuario = jwtToken.Claims.FirstOrDefault(c => c.Type == "Usuario")?.Value;
        var ordem = jwtToken.Claims.FirstOrDefault(c => c.Type == "ordem")?.Value;
        var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
        var demanda = jwtToken.Claims.FirstOrDefault(c => c.Type == "demanda")?.Value;
        var localidade = jwtToken.Claims.FirstOrDefault(c => c.Type == "Localidade")?.Value;
        var iss = jwtToken.Claims.FirstOrDefault(c => c.Type == "iss")?.Value;
        var aud = jwtToken.Claims.FirstOrDefault(c => c.Type == "aud")?.Value;

        var claims = new
        {
            UniqueName = uniqueName,
            Usuario = usuario,
            Ordem = ordem,
            Role = role,
            Demanda = demanda,
            Localidade = localidade,
            Iss = iss,
            Aud = aud
        };

        return Ok(claims);
    }

}

