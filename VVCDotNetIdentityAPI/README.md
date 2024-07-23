
## Projeto .NET Identity API Endpoints.

Este é um exemplo de projeto DotNet .NET Identity API Endpoints.

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Vscode](https://img.shields.io/badge/Vscode-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)

Repositório GitHub : 
https://github.com/ViniciusVC/dotnet/tree/main/VVCDotNetAPILogin

## .NET Identity
O ASP.NET Identity é um sistema completo para controle de login. É totalmente integrado com Blazor. O Identit API, só funciona a partir do com o .Net 8


# CRIANDO O PROJETO

Criar projeto ASP.NET Core API Minima com o comando dotnet new web:

> dotnet new web -n VVCDotNetIdentityAPI

> cd VVCDotNetIdentityAPI



## Instalar o pacote Asp.Net Identity.
```
> dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore

Conferir se instalou corretamente o Identity, no arquivo de projeto (VVCDotNetIdentityAPI.csproj). 
Instalou a versõa Version="8.0.7"
```

Instalar o Entity FrameworkCore para o QSLServer.
> dotnet add package Microsoft.EntityFrameworkCore.SqlServer

Instalar o Entity FrameworkCore para o MySQL.
> dotnet add package MySql.EntityFrameworkCore

Instalar o pacote EF que gera as Migrations.
> dotnet add package Microsoft.EntityFrameworkCore.Design 

## Criar Context e Model.
```
Crie o diretorio Data e a Class AppDbContext.cs
Crie o diretorio Models e a Class User.cs
```
## Em caso de erro. 
```
Faça uma limpesa do projeto antes de seguir:
> dotnet clean
> dotnet restore
```

## Configurações no Program.cs.
```
using Microsoft.EntityFrameworkCore;
using VVCDotNetIdentityAPI.Data;
using VVCDotNetIdentityAPI.Models;

builder.Services.AddDbContext<AddDbContext>(
    options => options.UseMySQL("Server=127.0.0.1;Port=3306;Database=dbvvclogin;Uid=root;Pwd=senharoot;")
);

builder.Services.AppAuthentication(); // Quem é.
builder.Services.AppAutorization(); // Quais permições tem.

builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<AppDbContext>();

app.MapIdentityApi<User>();
```
# Até aqui tudo funciona !!!!!!!

Verificar se o EF esta instlado..
> dotnet ef --version


Criar uma migração.
> dotnet ef migrations add v1

### Configurar banco
Veja em : /Docs/banco.md



### Não precisa instalar pacote EF Tools?
> dotnet add package Microsoft.EntityFrameworkCore.Tools


# Rodar aplicação:

> dotnet run

retorno em :

> http://localhost:5222