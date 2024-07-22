
# NOTAS

___________________________________________________________
# BANCO DE DADOS
Antes de iniciar o projeto inicie um banco para usa-lo de base.

Baichar a imagem do MySQl:
> docker pull mysql
Rodar contêiner MySQl:
> docker run -e MYSQL_ROOT_PASSWORD=senharoot --name vvc-mysql -d -p 3306:3306 mysql


### Acesso ao banco:
Hostname : 127.0.0.1
Port : 3306
Username : root
senha : senharoot
Banco de Dados : dbvvcinvestimentos

### C sharp
string connectionString = "Server=127.0.0.1;Port=3306;Database=dbvvcbiblioteca;Uid=root;Pwd=senharoot;";


___________________________________________________________
# CRIANDO A SOLUCAO
> dotnet new sln

___________________________________________________________
# CRIANDO PROJETO DOTNET CORE

// Criar projeto DotNet Core API:
> dotnet new webapi -n VVC.Biblioteca.API

// Entrar do doretorio do projeto:
> cd VVC.Biblioteca.API

// 1. Instale o pacote MySql.EntityFrameworkCore:
> dotnet add package MySql.EntityFrameworkCore --version 7.0.2

// 2. Instale o pacote Microsoft.EntityFrameworkCore.Tools
> dotnet add package Microsoft.EntityFrameworkCore.Tools

// 3. Restaure as dependências e ferramentas específicas do projeto:
> dotnet restore

// 4. Crie o modelo de Entity Framework Core executando o seguinte comando:
> dotnet ef dbcontext scaffold "Data Source=127.0.0.1:3306;Initial Catalog=dbvvcbiblioteca;Persist Security Info=True;User ID=root;Encrypt=False" MySql.EntityFrameworkCore -o sakila -f

___________________________________________________________

# Lixo

(Não funcionaram)

// 4. Crie o modelo de Entity Framework Core executando o seguinte comando:
> dotnet ef dbcontext scaffold "Data Source=127.0.0.1:3306;Initial Catalog=dbvvcbiblioteca;Persist Security Info=True;User ID=root;Encrypt=False" MySql.EntityFrameworkCore -o sakila -f

// Rode o scaffold
> dotnet ef dbcontext scaffold "Server=127.0.0.1:3306;Database=dbvvcbiblioteca;User Id=root;Password=senharoot;" MySql.EntityFrameworkCore

// Depois de instalar o pacote, você pode executar o comando > dotnet ef dbcontext scaffold 
// Para gerar as classes de dados do seu banco de dados MySQL.
