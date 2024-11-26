using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.Extensions.Configuration;
using VVCDotNetAPITokensJWT.Models;
using Microsoft.Extensions.Configuration;


namespace VVCDotNetAPITokensJWT.Services;

public class TokenService
{

    public string Generate(User user, string secretKey)
    {
        // Criar uma instância do JwtSecurityTokenHandler que gera o Token.
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(secretKey);
        // var key = Encoding.UTF8.GetBytes(Configuration.Privatekey);
        // var key = Encoding.ASCII.GetBytes(Configuration.Privatekey);


        // new SigningCredentials(CHAVE, ALGORITIMO)
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = credentials,

        };

        // Gera um Token.
        var token = handler.CreateToken(tokenDescriptor);

        // Gera uma string do Token.
        return handler.WriteToken(token);

    }


    private static ClaimsIdentity GenerateClaims(User user)
    {
        var ci = new ClaimsIdentity();
        ci.AddClaim(
            new Claim(ClaimTypes.Name, user.Email));

        //new claim(type:ClaimTypes.Name, value:user.Email))
        // ClaimTypes.Name -> User.Identity.Name
        // ClaimTypes.? -> Autorize

        foreach (var role in user.Roles)
            ci.AddClaim(new Claim(ClaimTypes.Role, role));

        //(type:chave, value:valor)

        return ci;
    }

}