## Minimal APIs CSharp

https://www.youtube.com/watch?v=AaLFxMztKwc

Nota : Minimal APIs não possui controllers.

Codificado no VSCode no Linux Ubuntu.

Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="7"

Include="microsoft.entityframeworkcore.inmemory" Version="7"


# Endpoints:

GET - /todoitems

GET - /todoitems/complete

GET - /todoitems/{id}

POST - /todoitems

PUT - /todoitems/{id}

DELETE - /todoitems/{id}

# Crie um projeto ASP NET CORE Empty

Projeto vazio. Projeto mínimo apenas para funcionar. Sem a ferramenta 

de visualizar API(Swagger).

# Comando para criar um projeto ASP.NET Core Empty:

 dotnet new web -n minimalapi

# Instale bibliotecas.

 Comando para instale a biblioteca InMemory neste projeto:
 
 dotnet add package microsoft.entityframeworkcore.inmemory

 Comando para instale a biblioteca Diagnostics neste projeto:

 dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 8.0.2

# Crie uma entidade (arquivo) Todo.cs:#

# Crie uma classe de contexto (TodoDb.cs) :

# Volte na Program.cs para mapear os endpoints.

# Rodar projeto:

 dotnet run

# testar endpoints:

Para testar todos os endpoints, instale a extensão Thunder Cliente no VSCode.
