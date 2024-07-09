using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// Classe contexto.

namespace VVCBotPessoal
{
    // Esta classe extende o DbContext
    public class ValorAcaoContext: DbContext
    {
        
        // No CONTEXT declare que a classe estudante é uma tabela.
        public DbSet<ValorAcao> ValorAcao {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Como se conectar com o banco de dados
            optionsBuilder.UseMySQL(connectionString: "Server=127.0.0.1;Port=3306;Database=dbvvcinvestimentos;Uid=root;Pwd=senharoot;");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }
    }


}