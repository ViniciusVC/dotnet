using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace VVC.Biblioteca.API.Models
{
// Classe Contexto de dados.

    public partial class DbvvcbibliotecaContext : DbContext
    {
        //public DbvvcbibliotecaContext()
        //{
        //}

        public DbvvcbibliotecaContext(DbContextOptions<DbvvcbibliotecaContext> options) : base(options)
        {
        }

        // DbSet<T> é parte do Entity Framework Core. É uma estrutura de Mapeamento Objeto-Relacional.


        //public DbSet<Cliente> cliente { get; set; } // Metodo instancia de cliente.
        //public DbSet<Livro> livro { get; set; } // Metodo instancia de livro.

        public virtual DbSet<Cliente> Clientes { get; set; } // coleção de entidades do tipo Cliente

        public virtual DbSet<Livro> Livros { get; set; } // coleção de entidades do tipo Livro

        public virtual DbSet<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; } // coleção de entidades do tipo LivroClienteEmprestimos

        // string MyStringConnection = Configuration.GetConnectionString("MySqlConnection");
        string MyStringConnection = "Server=127.0.0.1,3306;Database=dbvvcbiblioteca;User Id=root;Password=senharoot;";
        // Aviso : Para proteger informações potencialmente confidenciais na string de conexão,
        // preciso movêr a string de conexão para fora do código.
        // Para evitar o scaffolding da cadeia de conexão usando a sintaxe Name= para lê-la na configuração - consulte https://go.microsoft.com/fwlink/?linkid=2131148. 
        // Para obter mais orientações sobre como armazenar cadeias de conexão, consulte https://go.microsoft.com/fwlink/?LinkId=723263.


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL(MyStringConnection);
        
        // Criar entidades no context.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            //to change the name of table.
            //modelBuilder.Entity<Cliente>().ToTable("Users");

            //modelBuilder.Entity<Cliente>(entity =>
            //{
            //    entity.Property(o => o._id)
            //      .HasValueGenerator(typeof(ObjectIdValueGenerator));
            //    entity.HasIndex(o => o.Key).IsUnique();
            //    entity.Property(o => o.Value).IsRequired();
            //    entity.HasIndex(o => o.ProcTime).IsDescending();
            //    entity.ToCollection(nameof(Cliente));
            //});

            // Comportamento Cliente.
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY"); // chave da tabela é ID.
                entity.ToTable("Cliente"); // Nome da tabela

                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.Property(e => e.CliBairro)
                    .HasMaxLength(100)
                    .HasColumnName("cliBairro");
                entity.Property(e => e.CliCidade)
                    .HasMaxLength(100)
                    .HasColumnName("cliCidade");
                entity.Property(e => e.CliCpf)
                    .HasMaxLength(14)
                    .HasColumnName("cliCPF");
                entity.Property(e => e.CliEmail)
                    .HasMaxLength(100)
                    .HasColumnName("cliEmail");
                entity.Property(e => e.CliEndereco)
                    .HasMaxLength(200)
                    .HasColumnName("cliEndereco");
                entity.Property(e => e.CliNome)
                    .HasMaxLength(200)
                    .HasColumnName("cliNome");
                entity.Property(e => e.CliNumero)
                    .HasMaxLength(50)
                    .HasColumnName("cliNumero");
                entity.Property(e => e.CliTelefoneCelular)
                    .HasMaxLength(14)
                    .HasColumnName("cliTelefoneCelular");
                entity.Property(e => e.CliTelefoneFixo)
                    .HasMaxLength(14)
                    .HasColumnName("cliTelefoneFixo");
            });

            // Comportamento Livro
            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY"); // chave da tabela é ID.
                entity.ToTable("Livro"); // Nome da tabela
                
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.Property(e => e.LivroAnoPublicacao)
                    .HasColumnType("datetime")
                    .HasColumnName("livroAnoPublicacao");
                entity.Property(e => e.LivroAutor)
                    .HasMaxLength(200)
                    .HasColumnName("livroAutor");
                entity.Property(e => e.LivroEdicao)
                    .HasMaxLength(50)
                    .HasColumnName("livroEdicao");
                entity.Property(e => e.LivroEditora)
                    .HasMaxLength(100)
                    .HasColumnName("livroEditora");
                entity.Property(e => e.LivroNome)
                    .HasMaxLength(200)
                    .HasColumnName("livroNome");
            });

            // Comportamento EMPRESTIMO
            modelBuilder.Entity<LivroClienteEmprestimo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY"); // chave da tabela é ID.
                entity.ToTable("Livro_Cliente_Emprestimo"); // Nome da tabela
                entity.HasIndex(e => e.LceldCliente, "LceldCliente");
                entity.HasIndex(e => e.LceldLivro, "LceldLivro");
                
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.LceldEmprestimo)
                    .HasColumnType("date")
                    .HasColumnName("LceldEmprestimo");
                entity.Property(e => e.LceldEntrega)
                    .HasColumnType("date")
                    .HasColumnName("LceldEntrega");
                entity.Property(e => e.LceldEntregue)
                    .HasColumnType("bit(1)")
                    .HasColumnName("LceldEntregue");
                
                entity.HasOne(d => d.LceldClienteNavigation).WithMany(p => p.LivroClienteEmprestimos)
                    .HasForeignKey(d => d.LceldCliente)
                    .HasConstraintName("Livro_Cliente_Emprestimo_ibfk_1");

                entity.HasOne(d => d.LceldLivroNavigation).WithMany(p => p.LivroClienteEmprestimos)
                    .HasForeignKey(d => d.LceldLivro)
                    .HasConstraintName("Livro_Cliente_Emprestimo_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}


/*
Para acessar um método de manipulação de dados da classe DbContext no Entity Framework Core, você precisa instanciar a classe DbContext ou utilizar uma instância dela (geralmente injetada via dependência) e, em seguida, chamar os métodos apropriados, como Add, Update, Remove, SaveChanges, entre outros.
*/