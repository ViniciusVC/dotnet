
## VVC.DotNetMinimalAPI

Exemplo de Minimal APIs no .Net.

Codificado no VSCode no Linux Ubuntu.

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Vscode](https://img.shields.io/badge/Vscode-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![Linux](https://img.shields.io/badge/Linux-000?style=for-the-badge&logo=linux&logoColor=FCC624)

Repositorio GitHub : 
https://github.com/ViniciusVC/dotnet/tree/main/VVC.DotNetMinimalAPI

Nota : 
Minimal APIs não possui controllers. Ocultando classe host. Ideal para microsserviços.

Este projeto não possui um banco de dados real apenas in-memory (os  Dados não persistem).

# Rodar projeto:
$ dotnet run
![terminal API](docs/terminal.png "screenshot")
![navegador API](docs/navegador.png "screenshot")

# Endpoints:
```
Porta (dev): 5158

GET - "/"
// retorna "Minimal APIs C Sharp"
// Ex.: http://localhost:5158/

GET - "/todoitems"
// Retorna todos os itens de tarefas pendentes.
// Ex.: http://localhost:5158/todoitems

GET - "/todoitems/complete"
// retorna todos os itens.
// Ex.: http://localhost:5158/todoitems/complete

GET - "/todoitems/{id}"
// Passar um id e retorna a tarefa deacordo com o id.
// Ex.: http://localhost:5158/todoitems/0

POST - /todoitems 
// Adicionar o objeto com a tarefa.
// Ex.: http://localhost:5158/

PUT - "/todoitems/{id}"
// Atualizar a informação do objeto se ele não for nulo.
// Ex.: http://localhost:5158/

DELETE - "/todoitems/{id}" 
// Passsa ID e Objeto a ser deletado.
// Ex.: http://localhost:5158/
```

# Criar um projeto ASP.NET MinimalAPI:
```
$ dotnet new web -n minimalapi
//Projeto mínimo apenas para funcionar. 
//Sem a ferramenta de visualizar API(Swagger).
```

# Instale bibliotecas.
```
Comando para instale a biblioteca InMemory neste projeto:
 
$ dotnet add package microsoft.entityframeworkcore.inmemory --version 8

Comando para instale a biblioteca Diagnostics neste projeto:

$ dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 8

```

```
Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="7"
Include="microsoft.entityframeworkcore.inmemory" Version="7"
```


### Entidade
/src/Todo.cs

### Classe de contexto 
/src/TodoDb.cs


# endpoints:
```
(Get)/
(Get)/todoitems
(Get)/todoitems/complete
(Get)/todoitems/{id}
(Post)/todoitems
(PUT)/todoitems/{id}
(Delete)/todoitems/{id}
```

# Testar endpoints:
```
Para testar todos os endpoints no VSCode, use o Postman 
ou instale a extensão Thunder Cliente no VSCode.
```

# Punlish:
```
Publicar o projeto:
sudo dotnet publish --framework net8.0 --runtime osx-x64

Pasta de saida:
/VVC.DotNetMinimalAPI/src/bin/Release/net8.0/osx-x64

Rodar projeto publicado:
/bin/Release/net8.0/osx-x64$ dotnet minimalapi.dll

O projeto publicado roda na porta 5000.
http://localhost:5000/todoitems
```
