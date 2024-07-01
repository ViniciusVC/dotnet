/*
using System;
using System.Collections.Generic;
using System.Linq;
using VVC.VVC.Biblioteca.API.Model;

namespace VVC.VVC.Biblioteca.API.Application
{

    public class LivroService
    {
        private MySqlConnection _connection;
        
            private readonly IUserRepository _repository;

    public LivroService(IUserRepository repository)
    {
        _repository = repository;
    }

        public LivroService()
        {   
            // // String de conexão
            // IConfiguration config = new ConfigurationBuilder()
            //     .AddJsonFile("appsettings.json", optional: true)
            //     .Build();
            // string connectionString = config.GetConnectionString("MySqlConnection");

            //string server = "localhost";  
            string server = "127.0.0.1"; // IP do seu contêiner Docker.
            string port = "3306"; // Porta mapeada do MySQL.
            string database = "dbvvcbiblioteca"; // Nome do banco.
            string uid = "root"; // Usuario root
            string password = "senharoot";
            string connectionString = $"Server={server};Port={port};Database={database};Uid={uid};Pwd={password};";

            _connection = new MySqlConnection(connectionString);
        }

        public void ListarLivros()
        {   
            Console.WriteLine("Carregando lista de Livros...");
            ExibeLivros();
            Console.ReadKey(true);
        }
       
        public async void ExibeLivros()
        {   
            Task<List<Livro>> task = ListarLivrosDoBanco();
            List<Livro> livros = await task;
            Console.Clear();
            Console.WriteLine("Lista de Livros:");
            Console.WriteLine("=================================================");
            foreach (var livro in livros)
            {
                Console.WriteLine($"| Id: {livro.Id}, Nome: {livro.LivroNome}, Autor: {livro.LivroAutor}, Publicado: {livro.LivroAnoPublicacao}"); 
            }
            Console.WriteLine("=================================================");
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
        }
        

        private async Task<List<Livro>> ListarLivrosDoBanco()
        {
            List<Livro> livros = new List<Livro>();          

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Livro";
                await _connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Livro livro = new Livro
                        {
                            Id = reader.GetInt32(0),
                            LivroNome = reader.GetString(1),
                            LivroAutor = reader.GetString(2),
                            LivroEditora = reader.GetString(3),
                            LivroAnoPublicacao = reader.GetDateTime(4),
                            LivroEdicao = reader.GetString(5)
                        };
                        livros.Add(livro);
                    }
                }
            }
            _connection.Close();
            return livros;
        }
        
        public void CriarLivro()
        {
            Console.Write("Digite o nome do livro: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o autor do livro: ");
            string autor = Console.ReadLine();
            Console.Write("Digite a editora do livro: ");
            string editora = Console.ReadLine();
            Console.Write("Digite o ano de publicação do livro (9999): ");
            string tempData = Console.ReadLine();
            //DateTime anoPublicacao = DateTime.Parse("1999-01-01 104:00:00");
            //DateTime anoPublicacao = DateTime.Now();
            Console.Write("Digite a edição do livro: ");
            string edicao = Console.ReadLine();

            Livro livro = new Livro
            {
                LivroNome = nome,
                LivroAutor = autor,
                LivroEditora = editora,
                LivroAnoPublicacao = DateTime.Parse("01-01-"+tempData+" 104:00:00"),
                LivroEdicao = edicao
            };

            //_livros.Add(livro);

            CriarLivroNoBanco(livro);

            Console.WriteLine("Livro criado com sucesso!");
            Console.ReadKey(true);
        }
        

        //public async Task CriarLivro(Livro livro)
        private async Task CriarLivroNoBanco(Livro livro)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Livro (livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao) VALUES (@livroNome, @livroAutor, @livroEditora, @livroAnoPublicacao, @livroEdicao)";


                command.Parameters.AddWithValue("@livroNome", livro.LivroNome);
                command.Parameters.AddWithValue("@livroAutor", livro.LivroAutor);
                command.Parameters.AddWithValue("@livroEditora", livro.LivroEditora);
                command.Parameters.AddWithValue("@livroAnoPublicacao", livro.LivroAnoPublicacao);
                command.Parameters.AddWithValue("@livroEdicao", livro.LivroEdicao);

                await _connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }



        public void EditarLivro()
        {
            
            Console.Write("Digite o id do livro que deseja editar: ");
            int id = int.Parse(Console.ReadLine());
            
            //Livro livro = _livros.FirstOrDefault(l => l.Id == id);
            //if (livro == null)
            //{
            //    Console.WriteLine("Livro não encontrado.");
            //    return;
            //}           

            Console.Write("Digite o novo nome do livro: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o novo autor do livro: ");
            string autor = Console.ReadLine();
            Console.Write("Digite a nova editora do livro: ");
            string editora = Console.ReadLine();
            Console.Write("Digite o novo ano de publicação do livro: ");
            string tempData = Console.ReadLine();
            Console.Write("Digite a nova edição do livro: ");
            string edicao = Console.ReadLine();

            Livro livro = new Livro
            {
                LivroNome = nome,
                LivroAutor = autor,
                LivroEditora = editora,
                LivroAnoPublicacao = DateTime.Parse("01-01-"+tempData+" 104:00:00"),
                LivroEdicao = edicao
            };

            EditarLivroNoBanco(livro);
            _connection.Close();
            Console.Write("Livro alterado.");
            Console.ReadKey(true);
        }
        
        private async Task EditarLivroNoBanco(Livro livro)
        {
            using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Livro SET livroNome = @livroNome, livroAutor = @livroAutor, livroEditora = @livroEditora, livroAnoPublicacao = @livroAnoPublicacao, livroEdicao = @livroEdicao WHERE id = @id";
                    command.Parameters.AddWithValue("@id", livro.Id);
                    command.Parameters.AddWithValue("@livroNome", livro.LivroNome);
                    command.Parameters.AddWithValue("@livroAutor", livro.LivroAutor);
                    command.Parameters.AddWithValue("@livroEditora", livro.LivroEditora);
                    command.Parameters.AddWithValue("@livroAnoPublicacao", livro.LivroAnoPublicacao);
                    command.Parameters.AddWithValue("@livroEdicao", livro.LivroEdicao);

                    await _connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
        }
        

        public void DeletarLivro()
        {
            Console.Write("Digite o id do livro que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            DeletarLivroNoBanco(id);
            
            //Livro livro = _livros.FirstOrDefault(l => l.Id == id);
            //if (livro == null)
            //{
            //    Console.WriteLine("Livro não encontrado.");
            //    return;
            //}
            //_livros.Remove(livro);
            
            Console.WriteLine("Livro deletado com sucesso!");
            Console.ReadKey(true);
        }
        
        private async Task DeletarLivroNoBanco(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Livro WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                await _connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

    }


}
*/