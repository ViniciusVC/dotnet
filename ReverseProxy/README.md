
## REVERSEPROXY

# Proxy Reverso no .NET
```
Criando um projeto .NET para atuar como um proxy reverso.
Acessando ambos os projetos a partir de um único localhost.
Redirecionando as requisições para os dois projetos Node.js e .NET. 
Este é um exemplo de DotNet API, em codigo C#, codificado no VSCode no Linux Ubuntu.
```

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Vscode](https://img.shields.io/badge/Vscode-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)

https://github.com/ViniciusVC/dotnet/tree/main/reverseproxy


# Rorando aplicação
```
$ dotnet watch run
ou
$ dotnet run
```

## Para acessar os seus projetos use as seguintes URLs:

* Projeto Node.js: http://localhost:5000/node

* Projeto .NET: http://localhost:5000/dotnet

### Aplicações sem proxy

* swagger:
http://localhost:5192/swagger/index.html

* API DotNet:
http://localhost:5192/apilogin

* APP React:
http://localhost:3000/


# Criando este projeto:

### 1º Crie um novo projeto web mínimo ASP.NET Core:
> dotnet new web -n ReverseProxy
> cd ReverseProxy

### 2º Adicione o pacote YARP (Yet Another Reverse Proxy):
> dotnet add package Yarp.ReverseProxy

### 3º Configurações do proxy

Adiciar MapReverseProxy ao program.cs e Rotas no appsettings.json. 




