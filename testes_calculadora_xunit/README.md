# dotnet

Pequeno exemplo de Teste Unitario com xUnit no .Net Core 

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

https://github.com/ViniciusVC/dotnet/tree/main/testes_calculadora_xunit/

# Projetos nesta Solução 
```
/Calculadora
 (É um projeto de biblioteca de classes que podem ser referenciados a partir de aplicativos .NET Core)

/calculos.tests
 (projeto de teste .NET com xUnit)

```
Saida no terminal:
![teste xunit](./Screenshotteste_xunit.png "PrtSc")


# Comandos usados para criar o projeto:
```
Crie a pasta da solução para armazenar os projetos:
$ mkdir testes_calculadora_xunit

Entrar na pasta da solução:
$ cd estes_calculadora_xunit

Criar uma solução:
$ dotnet new sln -n testes_calculadora_xunit

Criar um projeto:
$ dotnet new classlib -n calculos

Criando o projeto de teste:
$ dotnet new xunit -n calculos.tests

Adicione este projeto na solução:
$ dotnet sln testes_calculadora_xunit add calculos.tests/calculos.tests.csproj

E adicione nele a referência da biblioteca de calculos nele:
$ dotnet add calculos.tests/calculos.tests.csproj reference calculos/calculos.csproj

Rodar aos testes:
$ dotnet test

```
