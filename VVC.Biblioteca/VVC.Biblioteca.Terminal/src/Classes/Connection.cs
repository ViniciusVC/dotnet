
using MySql.Data.MySqlClient;
using System;

namespace VVC.Biblioteca.Terminal{

    public class Connection
    {
        public void TestStringMySQL() 
        {


			// Instancia Views
			ConnectMessage connectMessage = new ConnectMessage(); 
            /*
            // String de conexão
            //string server = "localhost";  
            string server = "127.0.0.1"; // IP do seu contêiner Docker
            string port = "3306"; // Porta mapeada do MySQL
            string database = "dbvvcbiblioteca";
            string uid = "root";
            string password = "senharoot";
            string connectionString = $"Server={server};Port={port};Database={database};Uid={uid};Pwd={password};";
            */
            connectMessage = new ConnectMessage();
            var settings = new LerAppSettings();
            string connectionString = settings.ConnectionString();


            // Estabelece a conexão
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Conexão bem-sucedida");

                    // Executar uma consulta simples
                    MySqlCommand cmd = new MySqlCommand("SELECT DATABASE();", conn);
                    var result = cmd.ExecuteScalar();
                    Console.WriteLine($"Banco de dados atual: {result}");
                    connectMessage.Sucesso();   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro de conexão: " + ex.Message);
                    connectMessage.Erro();
                }
            }

        }
    }

    //interface ICalculadora
    //{
    //
    //}

}

