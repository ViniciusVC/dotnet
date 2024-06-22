/*
 Minimal APIs C#
 Nota : Minimal APIs não possui controllers.
 É um projeto vazio. 
 Projeto vom o mínimo, apenas para funcionar. 
 Sem a ferramenta de visualizar API (Swagger).

 Comando para criar um projeto ASP.NET Core Empty:
 $ dotnet new web -n minimalapi

 Comando para instale a biblioteca InMemory neste projeto:
 $ dotnet add package microsoft.entityframeworkcore.inmemory

 Aqui no Program.cs são definidas as rotas da aplicação.
*/

using Microsoft.EntityFrameworkCore;

/*
    // Ignorar bibliotecas criadas por padrão
    using System; //Manipular sitema operacional.
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq; // ṕara trabalhar com grande Conjunto de dados.
    using System.Text; // Manipular texto.
    using System.Threading.Tasks; // Processos paralelos (usa nucleos separados).
*/

using TodoApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt=> opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
                 

var app = builder.Build();


// Endpoint=================================================
app.MapGet("/", () => "Minimal APIs C Sharp");


// Endpoint=================================================
// simples. Todos os itens de tarefas pendentes.
// http://localhost:5158/todoitems
app.MapGet("/todoitems", async(TodoDb db) => await db.Todos.ToListAsync()); 


// Endpoint=================================================
// retorna todos os itens.
// http://localhost:5158/todoitems/complete
app.MapGet("/todoitems/complete", async(TodoDb db) =>  
    await db.Todos.Where(t => t.IsComplete).ToListAsync());


// Endpoint=================================================
// Passar um id e retorna a tarefa deacordo com o id.
// http://localhost:5158/todoitems/0
app.MapGet("/todoitems/{id}", async(int id,TodoDb db) => 
    await  db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound()); // Retorna "Ok" ou "não encontrado".


// Endpoint=================================================
// passar um objeto com a tarefa.
// Adicionar o objeto com a tarefa.
app.MapPost("/todoitems", async(Todo todo,TodoDb db) => 
{
        //Console.writeLine("Endpoint POST. Recebe um objeto com a tarefa. Adicionar o objeto com a tarefa. Retorna o ID criado.");
        db.Todos.Add(todo);
        await db.SaveChangesAsync();
        
        return Results.Ok(todo);
        //return Results.Created($"/todoitems/{todo.id}", todo); // Retorna o ID criado.
});


// Endpoint=================================================
// Rota PUT
// Atualizar a informação do objeto se ele não for nulo.
app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
{
    //Console.writeLine("Rota PUT. Atualizar a informação do objeto se ele não for nulo. Retorna mensagem de sucesso.");
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent(); // Retrona mensagem de sucesso.
});


// Endpoint=================================================
// Rota delete, passsa ID e Objeto.
app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    //Console.writeLine("Rota delete, rec recebe ID e Objeto. Retorna mensagem de sucesso ou não encontrado.");
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent(); // Retrona mensagem de sucesso.
    }
    return Results.NotFound(); // Retorna erro "não encontrado".
});

app.Run();
