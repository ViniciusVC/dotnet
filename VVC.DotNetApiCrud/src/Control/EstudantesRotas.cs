//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
//using Microsoft.EntityFrameworkCore;

using Apicrud.Data;
using Microsoft.EntityFrameworkCore;

// Class CONTROL/Rotas

namespace Apicrud.Estudante;


    public static class EstudantesRotas
    {
        // Incluindo o This no método( função) da classe controller, ele é chamada automaticamente no Program.cs.
        public static void AddRotasEstudantes(this WebApplication app)
        {

            //var rotasEstudantes:RouteGroupBuilder = app.MapGroup(prefix:"estudantes");
            var rotasEstudantes = app.MapGroup("/estudantes");
            
            //rotasEstudantes.MapPost("", async (Apicrud.Estudante.AddEstudanteRequest request, Apicrud.Data.AppDbContext context)=>
            rotasEstudantes.MapPost(pattern:"", handler:async (AddEstudanteRequest request, AppDbContext context, CancellationToken ct)=>
            {
                
                bool jaExiste;

                // Validar sse existe um estudante de mesmo nome já cadastrado.
                jaExiste = await context.Estudantes.AnyAsync(estudante => estudante.Nome == request.Nome); // Task<bool>

                
                if(jaExiste)
                {
                    // Se exite, retornar um erro.
                    return Results.Conflict(error:"Ja existe!");
                }
                else
                {
                    // Instancia um estutande com a informação que chegou no corpo da requisição.
                    var novoEstudante = new Estudante(request.Nome);

                    // Incluir o ESTUDANTE na lista de ESTUDANTES.
                    await context.Estudantes.AddAsync(novoEstudante, ct); // ct : irá parar o banco caso a processo morra no código.

                    // Aplicar todas as alterações ao banco.
                    await context.SaveChangesAsync();

                    // Mascarrar alguns campos para a API.
                    var estudanteRetorno = new EstudantesDto(novoEstudante.Id, novoEstudante.Nome); 

                    return Results.Ok(estudanteRetorno);
                }
            });


            rotasEstudantes.MapPost(pattern:"/gravasemvalidar", handler:async (AddEstudanteRequest request, AppDbContext context, CancellationToken ct)=>
            {
                // Instancia um estutande com a informação que chegou no corpo da requisição.
                var novoEstudante = new Estudante(request.Nome);

                // Incluir o ESTUDANTE na lista de ESTUDANTES.
                await context.Estudantes.AddAsync(novoEstudante, ct); // ct : irá parar o banco caso a processo morra no código.

                // Aplicar todas as alterações ao banco.
                await context.SaveChangesAsync();
            });


            // retornar Todos os Estudantes cadastrados flegados como ativos.
            rotasEstudantes.MapGet(pattern:"", handler:async (AppDbContext context, CancellationToken ct) =>
            {
                //List<Estudantes> 
                var estudantes = await context
                    .Estudantes
                    .Where(estudante => estudante.Ativo)
                    .Select(estudante => new EstudantesDto(estudante.Id, estudante.Nome)) // Mascarrar alguns campos para a API.
                    .ToListAsync(ct);  // ct : irá parar o banco caso a processo morra no código.
                // Não precisa do SaveChangesAsync(), porque não tem alteração no banco.

                return estudantes;
            });

            // Atualizar Nome estudante
            rotasEstudantes.MapPut(pattern:"{id:guid}", handler:async (Guid id,updateEstudanteRequest request, AppDbContext context, CancellationToken ct) =>
            {
                // Buscar estudante com msmo id.
                var estudante = await context.Estudantes
                    .SingleOrDefaultAsync(estudante => estudante.Id == id, ct);

                
                if (estudante==null)    
                {
                    // Estudante NÃO existe no banco.
                    return Results.NotFound();
                }
                else
                {
                    // Estudante EXISTE no banco.

                    // Aplicar novo nome ao estudante.
                    estudante.AtualizarNome(request.Nome);

                    // Aplicar todas as alterações ao banco.
                    await context.SaveChangesAsync(ct);

                    // Mascarrar alguns campos para a API.
                    var estudanteRetorno = new EstudantesDto(estudante.Id, estudante.Nome); 

                    return Results.Ok(estudanteRetorno);
                }            
            });



            // Deletar
            rotasEstudantes.MapDelete(pattern:"{id}", handler:async (Guid id, AppDbContext context, CancellationToken ct) =>
            {
                // Buscar estudante com msmo id.
                var estudante = await context.Estudantes
                    .SingleOrDefaultAsync(estudante => estudante.Id == id, ct);

                
                if (estudante==null)    
                {
                    // Estudante NÃO existe no banco.
                    return Results.NotFound();
                }
                else
                {
                    // Estudante EXISTE no banco.

                    // Aplicar novo nome ao estudante.
                    estudante.Desativar();

                    // Aplicar todas as alterações ao banco.
                    await context.SaveChangesAsync(ct);

                    return Results.Ok();
                }            
            });



            /*
            app.MapPost("estudantes")
            app.MapGet(pattern: "estudantes", 
                handler:() => new Estudante(nome:"Vinicius"));
            */
        }

    }


