//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Data.Common;

using Apicrud.Estudante;
using Microsoft.EntityFrameworkCore;

// Classe contexto.

namespace Apicrud.Data;

    // Etsa classe extende o DbContext
    public class AppDbContext : DbContext
    {
        
        // No CONTEXT declare que a classe estudante é uma tabela.
        public DbSet<Apicrud.Estudante.Estudante> Estudantes {get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Como se conectar com o banco de dados
            optionsBuilder.UseSqlite(connectionString: "Data Source=Banco.sqlite");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }

    }
