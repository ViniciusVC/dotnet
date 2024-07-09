using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting; //Tentativa-2
using System.IO;

/*=====================================================

Ler a string de conexão do appsettings.json.

Ao contrário de um projeto ASP.NET Core, você precisa criar e ler o arquivo appsettings.json manualmente em um projeto .NET Console. 
E ler as configurações usando o IConfiguration.

Instale o Configuration.Json:
> dotnet add package Microsoft.Extensions.Configuration.Json
Instale o Hosting:
> dotnet add package Microsoft.Extensions.Hosting

=====================================================*/

namespace VVC.Biblioteca.Terminal{

    public class LerAppSettings
    {

            public string ConnectionString()
            {
                Console.WriteLine("Lendo AppSettings.json...");
                var host = Host.CreateDefaultBuilder().Build();
                var config = (IConfiguration)host.Services.GetService(typeof(IConfiguration));
                var mySetting = config["MySetting"];
                return mySetting;
            } 


            public string ConnectionString2()
            {
                // =====================================
                // !!! Este metodo deve ser apagado. !!!
                // =====================================

                // String de conexão
                //string server = "localhost";
                string server = "127.0.0.1"; // IP do seu contêiner Docker
                string port = "3306"; // Porta mapeada do MySQL
                string database = "dbvvcbiblioteca";
                string uid = "root";
                string password = "senharoot";
                string connectionString = $"Server={server};Port={port};Database={database};Uid={uid};Pwd={password};";           
                return connectionString;  
            } 



 
    }
}

