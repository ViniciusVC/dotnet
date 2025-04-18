﻿using System;
using System.Text;
using System.Security.Claims; // < -- para incluir informações no Tokem.
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

        var key = Encoding.ASCII.GetBytes(secretKey); // Lendo a secretKey do appsettings.
        // var key = Encoding.UTF8.GetBytes(Configuration.Privatekey);


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

    public string GenerateTesteE(TesteE testeE, string secretKey)
    {
        // Criar uma instância do JwtSecurityTokenHandler que gera o Token.
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(secretKey); // Lendo a secretKey do appsettings.
        // var key = Encoding.UTF8.GetBytes(Configuration.Privatekey);


        // new SigningCredentials(CHAVE, ALGORITIMO)
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaimsTesteE(testeE),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = credentials,
        };

        // Gera um Token.
        var token = handler.CreateToken(tokenDescriptor);

        // Gera uma string do Token.
        return handler.WriteToken(token);

    }


    private static ClaimsIdentity GenerateClaimsTesteE(TesteE testeE)
    {

        var ci = new ClaimsIdentity();

        foreach (var i in testeE.Unique_name)
            ci.AddClaim(new Claim(ClaimTypes.Name, i));
            ci.AddClaim(new Claim("Usuario", testeE.Usuario));
            ci.AddClaim(new Claim("Ordem", testeE.Ordem));
            ci.AddClaim(new Claim("Role", testeE.Role));
            ci.AddClaim(new Claim("Demanda", testeE.Demanda));
            ci.AddClaim(new Claim("Localidade", testeE.Localidade));
            ci.AddClaim(new Claim("Iss", testeE.Iss));
            ci.AddClaim(new Claim("Aud", testeE.Aud));

        return ci;
    }

}