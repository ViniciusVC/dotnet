using System;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;



namespace VVC.Biblioteca.Terminal.Model
{
    class EmprestimoContexto
    {

        private MySqlConnection _connection;
        
        private ConnectMessage connectMessage;


        public EmprestimoContexto()
        {   
            connectMessage = new ConnectMessage();
            var settings = new LerAppSettings();
            string connectionString = settings.ConnectionString();
            _connection = new MySqlConnection(connectionString);
        }

        
        // Listar livros emprestados.
        public async Task<List<Emprestimo>> ListarEmprestimosDoBanco()
        {
            List<Emprestimo> emprestimos = new List<Emprestimo>();          
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT e.id, l.id, l.livroNome, c.id, c.cliCPF, c.cliNome, e.LceldEmprestimo  from Cliente c JOIN Livro_Cliente_Emprestimo e ON c.id=e.LceldCliente JOIN Livro l ON e.LceldLivro = l.id WHERE e.LceldEntregue=0 Order By e.LceldEmprestimo";
                await _connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Emprestimo emprestimo = new Emprestimo
                        {

                            Id = reader.GetInt32(0),//id 
                            LceldLivro = reader.GetInt32(1),//livro.id
                            livroNome = reader.GetString(2),//livroNome
                            LceldCliente = reader.GetInt32(3),//cliente.id
                            cliCPF = reader.GetString(4),//cliCPF
                            cliNome = reader.GetString(5),//cliNome
                             LceldEmprestimo = reader.GetDateTime(6).ToString()//LceldEmprestimo "2020-10-10"
                        };
                        emprestimos.Add(emprestimo);
                    }
                }//reader.GetDateTime(6).ToString()
            }
            _connection.Close();
            return emprestimos;
        }
        
        // Listar livros emprestados para um cliente. 
        public async Task<List<Emprestimo>> ListarEmprestimosClienteDoBanco(int idCliente)
        {
            List<Emprestimo> emprestimos = new List<Emprestimo>();          

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"select l.id, l.livroNome, c.id, c.cliCPF, c.cliNome, e.LceldEmprestimo  from Cliente c JOIN Livro_Cliente_Emprestimo e ON c.id=e.LceldCliente JOIN Livro l ON e.LceldLivro = l.id WHERE e.LceldEntregue=0 AND c.id={idCliente} Order By e.LceldEmprestimo";
                await _connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Emprestimo emprestimo = new Emprestimo
                        {
                            Id = reader.GetInt32(0),
                            LceldLivro = reader.GetInt32(1),
                            livroNome = reader.GetString(2),
                            LceldCliente = reader.GetInt32(3),
                            cliCPF = reader.GetString(4),
                            cliNome = reader.GetString(5),
                            LceldEmprestimo = reader.GetDateTime(6).ToString()
                        };
                        emprestimos.Add(emprestimo);
                    }
                }
            }
            _connection.Close();
            return emprestimos;
        }

        public async Task<bool> CriarEmprestimoNoBanco(int idCliente, int idLivro)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Livro_Cliente_Emprestimo(LceldCliente, LceldLivro, LceldEmprestimo, LceldEntregue) VALUES (@LceldCliente, @LceldLivro, @LceldEmprestimo, @LceldEntregue)";
                command.Parameters.AddWithValue("@LceldCliente", idCliente);
                command.Parameters.AddWithValue("@LceldLivro", idLivro);
                command.Parameters.AddWithValue("@LceldEmprestimo", "2023-01-10");
                command.Parameters.AddWithValue("@LceldEntregue", false);
                await _connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            _connection.Close();
            return true;
        }


        // Devolver livro 
        public async Task<bool> DevolveLivroNoBanco(int idCliente, int idLivro)
        {
            // Falta Data de entrega. 
            using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "Update Livro_Cliente_Emprestimo Set LceldEntrega=@DataEntrega, LceldEntregue=@LceldEntregue Where LceldCliente=@idCliente AND LceldLivro=@idLivro";
                    command.Parameters.AddWithValue("@idLivro", idLivro);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.Parameters.AddWithValue("@DataEntrega", "2020-05-13"); 
                    command.Parameters.AddWithValue("@LceldEntregue", true);
                    await _connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    // _connection.Close();
                }
            _connection.Close();
            return true;
        }
              

        
    }
}