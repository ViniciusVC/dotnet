# VVCDotNetAPIScalar

## Swagger e Scalar
No DotNet 9 o Swagger foi descontinuado.
Neste projeto estou usando o Scalar como substituto ao Swagger.

## Projeto API com Token JWT.

Este e um exemplo de projeto DotNet API com Token usando Scalar.

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

https://github.com/ViniciusVC/dotnet/tree/main/VVC.DotNetAPIAPITokensJWT


# Rorando projeto:
```
$ dotnet run
```

# Abre o Scalar em:
> http://localhost:5016/scalar/v1


### Dependencia JWTBearer
```
Instalar pacote JwtBearer:
dotnet add package Microsoft.AspNetCore.Authentication --version 7.0.9
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.9

Instalar pacote Configuration, para ler o appsetings:
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json

Instalar o Scalar:
dotnet add package Scalar.AspNetCore

Ou adicione os pacotes via nuguet.
```

### nota:
para testes locais manter a validacao de Issuer desativada:
> ValidateIssuer = false,


# testando a aplicacao

* Gerar um Token JWT:

> Use o endpoint para gerar um token JWT.

* Enviar o Token JWT no Cabecalho da Requisicao:

Use uma ferramenta como Postman ou cURL para enviar uma requisicao ao endpoint protegido, incluindo o token JWT no cabecalho Authorization.

Exemplo com cURL:

> curl -H "Authorization: Bearer YOUR_JWT_TOKEN" http://localhost:5217/Api/Protected/default

ou

> curl -H "Authorization: Bearer YOUR_JWT_TOKEN" http://localhost:5217/Api/Protected/user
