using System;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;

// using Microsoft.Extensions.Configuration; // String de conexão.

namespace VVC.Biblioteca.Terminal
{
    class ClienteContexto
    {

        private MySqlConnection _connection;
        
        private ConnectMessage connectMessage;

        public ClienteContexto()
        {   
            
            connectMessage = new ConnectMessage();

            /*
            // String de conexão
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            string connectionString = config.GetConnectionString("MySqlConnection");
            */

            //string server = "localhost";  
            string server = "127.0.0.1"; // IP do seu contêiner Docker.
            string port = "3306"; // Porta mapeada do MySQL.
            string database = "dbvvcbiblioteca"; // Nome do banco.
            string uid = "root"; // Usuario root
            string password = "senharoot";
            string connectionString = $"Server={server};Port={port};Database={database};Uid={uid};Pwd={password};";

            _connection = new MySqlConnection(connectionString);
        }

        

        public async Task<List<Cliente>> ListarClientesDoBanco()
        {
            List<Cliente> clientes = new List<Cliente>();          

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Cliente";
                await _connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Cliente cliente = new Cliente
                        {
                            Id = reader.GetInt32(0),
                            CliCPF = reader.GetString(1),
                            CliNome = reader.GetString(2),
                            CliEndereco = reader.GetString(3),
                            CliCidade = reader.GetString(4),
                            CliBairro = reader.GetString(5),
                            CliNumero = reader.GetString(6),
                            CliTelefoneCelular = reader.GetString(7),
                            CliTelefoneFixo = reader.GetString(8),
                            CliEmail = reader.GetString(9)
                        };
                        clientes.Add(cliente);
                    }
                }
            }
            _connection.Close();
            return clientes;
        }
        
        
        public async Task<bool> CriarClienteNoBanco(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Cliente (cliCPF, cliNome, cliEndereco, cliCidade, cliBairro, cliNumero, cliTelefoneCelular, cliTelefoneFixo, cliEmail) VALUES @cliCPF, @cliNome, @cliEndereco, @cliCidade, @cliBairro, @cliNumero, @cliTelefoneCelular, @cliTelefoneFixo, @cliEmail)";
                command.Parameters.AddWithValue("@cliCPF", cliente.CliCPF);
                command.Parameters.AddWithValue("@cliNome", cliente.CliNome);
                command.Parameters.AddWithValue("@cliEndereco", cliente.CliEndereco);
                command.Parameters.AddWithValue("@cliCidade", cliente.CliCidade);
                command.Parameters.AddWithValue("@cliBairro", cliente.CliBairro);
                command.Parameters.AddWithValue("@cliNumero", cliente.CliNumero);
                command.Parameters.AddWithValue("@cliTelefoneCelular", cliente.CliTelefoneCelular);
                command.Parameters.AddWithValue("@cliTelefoneFixo", cliente.CliTelefoneFixo);
                command.Parameters.AddWithValue("@cliEmail", cliente.CliEmail);
                await _connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            _connection.Close();
            return true;
        }


        
        public async Task<bool> EditarClienteNoBanco(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Cliente SET cliCPF=@cliCPF, cliNome=@cliNome, cliEndereco=@cliEndereco, cliCidade=@cliCidade, cliBairro=@cliBairro, cliNumero=@cliNumero, cliTelefoneCelular=@cliTelefoneCelular, cliTelefoneFixo=@cliTelefoneFixo, cliEmail=@cliEmail WHERE id = @id";
                    command.Parameters.AddWithValue("@id", cliente.Id);
                    command.Parameters.AddWithValue("@cliCPF", cliente.CliCPF);
                    command.Parameters.AddWithValue("@cliNome", cliente.CliNome);
                    command.Parameters.AddWithValue("@cliEndereco", cliente.CliEndereco);
                    command.Parameters.AddWithValue("@cliCidade", cliente.CliCidade);
                    command.Parameters.AddWithValue("@cliBairro", cliente.CliBairro);
                    command.Parameters.AddWithValue("@cliNumero", cliente.CliNumero);
                    command.Parameters.AddWithValue("@cliTelefoneCelular", cliente.CliTelefoneCelular);
                    command.Parameters.AddWithValue("@cliTelefoneFixo", cliente.CliTelefoneFixo);
                    command.Parameters.AddWithValue("@cliEmail", cliente.CliEmail);

                    await _connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    // _connection.Close();
                }
            _connection.Close();
            return true;
        }
              

        public async Task<bool> DeletarClienteNoBanco(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Cliente WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                await _connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                // _connection.Close();
            }
            Console.WriteLine("Cliente id="+id+" deletado.");
            _connection.Close();
            return true;
        }
        
    }
}