# Tokens JWT 

Pequeno exemplo de gerador de Token com JWT no .Net.

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

GitHub : https://github.com/ViniciusVC/dotnet/tree/main/VVCDotNetGeraTokensJWT/


Saida no terminal:


# Criar a solução:
```
mkdir VVCDotNetTokensJWT
cd VVCDotNetTokensJWT
dotnet new web
```

# Rodando projeto
> cd VVCDotNetTokensJWT

Rodar projeto: 
>  dotnet run

Rodar com atualização automatica:
> dotnet watch run

Rodar o projeto de fora do diretorio:
> dotnet run --project ./VVC.APICalculadoraXUnit.API/VVC.APICalculadoraXUnit.API.csproj

### saida
![ProjetoConsolePrtSc](docs/PrtScr_saida.jpg "PrtScConsole")

### Token gerado:
```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3RlQHRlc3RlLmNvbSIsInJvbGUiOlsic3R1ZGVudCIsInByZW1pdW0iXSwibmJmIjoxNzMyNjE5MzU4LCJleHAiOjE3MzI2MjY1NTgsImlhdCI6MTczMjYxOTM1OH0.zykGR9Kehnp-R5QgwKS8Is47Iv_OaF9yX9JIHmo2Geo
```

### Verificar em https://jwt.io/
![ProjetoConsolePrtSc](docs/PrtScr_jwt_io.jpg "PrtScConsole")

### Dependencia JWTBearer
```
Instalar pacote JwtBearer:
dotnet add package Microsoft.AspNetCore.Authentication --version 7.0.9
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.9

ou

Adicione o pacote JWTBearer via nuguet:
Microsoft.AspNetCore.Authentication.JwtBearer.
```

## Estrutura
Models/User.cs
Repositories/UserRepository.cs

### Abra o Swagger em:
> http://localhost:5003/swagger/index.html

