# dotnet

Projeto de exemplo ASP.NET MVC com Razor Pages, SQLite e login.

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

 
## Criar o projeto Razor Pages (com Login).
> dotnet new razor -o VVC.SisCTRazorPages -f net8.0 --auth Individual


Instalar o SQLite no projeto:
> dotnet add package Microsoft.EntityFrameworkCore.Sqlite

## Rode o projeto
```
dotnet run
Ou rodar o projeto atualisando automaticamente:
dotnet watch run
```

Acesse o site do projeto em:
```
http://localhost:5071
(Confira a porta.)
```

Codigo:
```
Criar as classes Model:
Cliente.cs e Curso.cs
Incluir referências as tabelas no context.
```

## Instalar o ef
> dotnet tool install --global dotnet-ef

Execute uma limpeza:
```
dotnet clean
dotnet restore
```

## migrations
```
Adicionar migrations ao projeto
> dotnet ef migrations add migracao1
  (Prepara o stript para a migração)

Aplicar ao banco:
> dotnet ef database update
  (Gera as tabelas no SQLite, baseado nas nossas classes)
```

Execute uma limpeza:

```
dotnet clean
dotnet build
```


Instalar o Code Generator (criar os páginas automaticamente.)
> dotnet tool install -g dotnet-aspnet-codegenerator

Instale um pacote Code Generation Design.
> dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design


## Gerar as página de Aluno
```
dotnet aspnet-codegenerator razorpage Cadastro Create -m Aluno -dc ApplicationDbContext -sqlite -udl -outDir Pages/Aluno
dotnet aspnet-codegenerator razorpage Editar Edit -m Aluno -dc ApplicationDbContext -sqlite -udl -outDir Pages/Aluno
dotnet aspnet-codegenerator razorpage Apagar Delete -m Aluno -dc ApplicationDbContext -sqlite -udl -outDir Pages/Aluno
dotnet aspnet-codegenerator razorpage Index List -m Aluno -dc ApplicationDbContext -sqlite -udl -outDir Pages/Aluno
```

## Gerar as página de Aluno
```
dotnet aspnet-codegenerator razorpage Cadastro Create -m Curso -dc ApplicationDbContext -sqlite -udl -outDir Pages/Curso
dotnet aspnet-codegenerator razorpage Editar Edit -m Curso -dc ApplicationDbContext -sqlite -udl -outDir Pages/Curso
dotnet aspnet-codegenerator razorpage Apagar Delete -m Curso -dc ApplicationDbContext -sqlite -udl -outDir Pages/Curso
dotnet aspnet-codegenerator razorpage index List -m Curso -dc ApplicationDbContext -sqlite -udl -outDir Pages/Curso
```

Detalhes
```
aspnet-codegenerator : gerar código
razorpage : codigo no estilo Razor Page
Create : Nome da página
-udl : layout padrão do dotnet
-outDir Pages/Aluno : Diretório de saída , onde será criado o código da página.
```



