
## Projeto API Login.

Este é um exemplo de projeto DotNet API com login de usuário, usando o Identity API.


![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Vscode](https://img.shields.io/badge/Vscode-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)

Repositório GitHub : 
https://github.com/ViniciusVC/dotnet/tree/main/VVCDotNetAPILogin

# CRIANDO O PROJETO

### 1º Criar a solução.
```
> mkdir VVCDotNetAPILogin
> cd VVCDotNetAPILogin
> dotnet new sln -n VVCDotNetAPILogin
```

### 2º criar o projeto Web API.

> dotnet new webapi -n VVCDotNetAPILogin.API

### 3º Adicione este projeto na solução.

> dotnet sln VVCDotNetAPILogin.sln add VVCDotNetAPILogin.
API/VVCDotNetAPILogin.API.csproj

### 4º Abrir no VSCode.
> code

### 5º Instalar o pacote.
> dotnet add package Microsoft.AspNetCore.identity.EntityFrameworkCore

### 6º Conferir se instalou corretamente.
Abra o arquivo de projeto (VVCDotNetAPILogin.API.csproj)

### 7º Instalar pacotes para o Banco de Dados (MySQL).
Instale o pacote MySql.Entity Framework Core:
> dotnet add package MySql.EntityFrameworkCore

(ou dotnet add package MySql.EntityFrameworkCore --version 7.0.2)

Instale o pacote Microsoft.EntityFrameworkCore.Tools
> dotnet add package Microsoft.EntityFrameworkCore.Tools

### 8º Instalar o Entity FrameworkCore.
> dotnet add package Microsoft.EntityFrameworkCore.Design 

### 9º Criar Model.
Crie o diretorio Models e a Class User.cs

### 10º Criar AppDbContext.
Crie o diretorio Data e a Class AppDbContext.cs

### 11º Configurações no Program.cs.
Incluir builder.Services.

### 11º Verificar se o EF esta instlado..
dotnet ef --version



### Criar uma migração.
dotnet ef migrations add v1

# Em caso de ERRO
```
Faça uma limpesa do projeto antes de seguir:
> dotnet clean
> dotnet restore
```

# RODAR PROJETO 
> dotnet run

### SWEGGER
```
Abra o Swagger em:
http://localhost:5192/swagger/index.html
(Apenas para teste de API.)
```
![navegador swagger](docs/screenshot_swagger_dotnet.jpg "screenshot")


# PUBLICAR PROJETO:
```
Publicar o projeto:
sudo dotnet publish --framework net8.0 --runtime osx-x64

Pasta de saida:
/VVC.DotNetAPICalculadora/src/bin/Release/net8.0/osx-x64

Rodar projeto publicado:
/bin/Release/net8.0/osx-x64$ dotnet CalculadoraSimplesAPI.dll

O projeto publicado(produção) roda na porta 5000.
http://localhost:5000/api/
```

# Banco De Dados 
Veja em : /Docs/banco.md


# DOCKER
```
Para gerar a imagem:
$ sudo docker build . -t vvcdotnetapicalculadoraimg

Criar um contêiner a partir da imagem que vc criou:
$ sudo docker run -d -p 5000:5271 --name dotnet_api_calculadora vvcdotnetapicalculadoraimg

Para a execução do contêiner: 
$ sudo docker stop dotnet_api_calculadora
```
