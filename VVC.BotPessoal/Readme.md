## VVC.BotPessoa

Este é um bot simples dotnet.
Projeto DotNet Core do tipo console.

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Vscode](https://img.shields.io/badge/Vscode-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)


Repositorio no GIT :
https://github.com/ViniciusVC/dotnet/tree/main/VVC.BotPessoa

# Rodar projeto:

> $ dotnet run

![DockerMySQLPrtSc](Docs/botpessoal.jpg "PrtScMySql")

## Instalar o DotNet no Ubuntu:
> sudo apt-get install -y dotnet-sdk-8.0

## Iniciando projeto:
```
 Crie uma pasta para o projeto:
 $ mkdir VVC.BotPessoa
 $ cd VVC.BotPessoa
 Iniciei um projeto de terminal:
 $ dotnet new console
``` 

# Instalando pacotes Selenium:
```
 Instalar biblioteca:
 & dotnet add package Selenium.WebDriver
 Instalar drives do Chrome:
 $ dotnet add package Selenium.Chrome.WebDriver
 Instalar drives do FireFox:
 $ dotnet add package Selenium.Gecko.WebDriver
```

# Banco de Dados
```
Baixar a imagem do mySQL
c:/> docker pull mysql

Rodar o banco de dados:
C:/> docker run -e MYSQL_ROOT_PASSWORD=senharoot --name vvc-mysql -d -p 3306:3306 mysql

Acesso ao banco:
Hostname : 127.0.0.1
Port : 3306
Username : root
senha : senharoot
Banco de Dados : dbvvcbiblioteca;

Acessar terminal MySQL: 
$ mysql -uroot -p
/p (A porta TCP/IP atual ou arquivo de soquete)

Parar contêiner MySQl:
C:/> docker stop vvc-mysql

Verificar o Ip do contêiner:
C:/> docker inspect vvc-mysql | grep IPAdress

Veja mais no arquivo:
/Docs/CriandoBancoBiblioteca.txt

```
![DockerMySQLPrtSc](Docs/mysqldocker.jpg "PrtScMySql")



Confirmar se o EF está instalado no seu projeto:

> dotnet ef

Se não estiver instale o ef (Entity Framework) como uma ferramenta global:

> dotnet tool install --global dotnet-ef

## 1º Instalar o EF

Instale EF no seu projeto:

> dotnet add package Microsoft.EntityFrameworkCore

## 2º Instalar o pacote para o Banco de Dados que irá usar.
```
instalar o SQLite para EF:
> dotnet add package MySql.EntityFrameworkCore

No CONTEXT declare que a classe estudante é uma tabela.
> private DbSet< ValorAcao > Estudantes(get;set;)

Instale o pacote Microsoft.EntityFrameworkCore.Design:
> dotnet add package Microsoft.EntityFrameworkCore.Design

Instale o pacote Microsoft.EntityFrameworkCore.Tools:
> dotnet add package Microsoft.EntityFrameworkCore.Tools
```
