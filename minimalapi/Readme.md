
## Minimal APIs CSharp

Exemplo de Minimal APIs no .Net
Codificado no VSCode no Linux Ubuntu.

/minimalapi/

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Vscode](https://img.shields.io/badge/Vscode-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![Linux](https://img.shields.io/badge/Linux-000?style=for-the-badge&logo=linux&logoColor=FCC624)

https://github.com/ViniciusVC/dotnet/tree/main/minimalapi

Nota : Minimal APIs não possui controllers. Ocultando classe host. Ideal para microsserviços.

Neste projeto Dados não persistem, o banco de dados é in-memory.

```
Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="7"
Include="microsoft.entityframeworkcore.inmemory" Version="7"
```

# Endpoints:
```
Porta : 5158

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

# Crie um projeto ASP NET CORE Empty
```
Projeto vazio. Projeto mínimo apenas para funcionar. Sem a ferramenta de visualizar API(Swagger).
```
# Comando para criar um projeto ASP.NET Core Empty:
```
$ dotnet new web -n minimalapi
```
# Instale bibliotecas.
```
Comando para instale a biblioteca InMemory neste projeto:
 
$ dotnet add package microsoft.entityframeworkcore.inmemory --version 7

Comando para instale a biblioteca Diagnostics neste projeto:

$ dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 7
```

# Crie uma entidade (arquivo) Todo.cs:#

# Crie uma classe de contexto (TodoDb.cs) :

Volte na Program.cs para mapear os endpoints.

# Rodar projeto:

$ dotnet run
![terminal API](wwwroot/images/terminal.png "screenshot")
![navegador API](wwwroot/images/navegador.png "screenshot")

# testar endpoints:
```
Para testar todos os endpoints, instale a extensão Thunder Cliente no VSCode.
```


