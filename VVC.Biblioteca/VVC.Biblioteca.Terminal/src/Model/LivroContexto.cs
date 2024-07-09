using System;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;

// using Microsoft.Extensions.Configuration; // String de conexão.

namespace VVC.Biblioteca.Terminal.Model
{
    class LivroContexto
    {

        private MySqlConnection _connection;
        
        private ConnectMessage connectMessage;
        private string connectionString;

        public LivroContexto()
        {   
            connectMessage = new ConnectMessage();
            var settings = new LerAppSettings();
            connectionString = settings.ConnectionString();           
            _connection = new MySqlConnection(connectionString);
        }

        

        public async Task<List<Livro>> ListarLivrosDoBanco()
        {
            List<Livro> livros = new List<Livro>();          

            Console.WriteLine("conexao : "+connectionString);

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
        
        
        public async Task<bool> CriarLivroNoBanco(Livro livro)
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
            _connection.Close();
            return true;
        }



        
        public async Task<bool> EditarLivroNoBanco(Livro livro)
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
                    // _connection.Close();
                }
            _connection.Close();
            return true;
        }
              

        public async Task<bool> DeletarLivroNoBanco(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Livro WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                await _connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                // _connection.Close();
            }
            Console.WriteLine("Livro id="+id+" deletado.");
            _connection.Close();
            return true;
        }
        
    }
}