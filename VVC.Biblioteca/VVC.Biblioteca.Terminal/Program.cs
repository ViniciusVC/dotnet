using System; //Manipular sitema operacional.
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq; // ṕara trabalhar com grande Conjunto de dados.
using System.Text; // Manipular texto.
using System.Threading.Tasks; // Processos paralelos (usa nucleos separados).


namespace VVC.Biblioteca.Terminal
{
    class Program
    {
    	// O metodo Main é o primeiro que é execuado.
		static void Main(string[] args)
		{
			
			// Instancia classes
			Menu menu = new Menu(); 
			UsarCalculadora usarCalculadora = new UsarCalculadora();
			MenuLivroDB menuLivroDB = new MenuLivroDB();
			MenuClienteDB menuClienteDB = new MenuClienteDB();
			Sair sairPrograma = new Sair();
			ErroMenu erroMenu = new ErroMenu();
			ILogger logger = new ConsoleLogger();

			//private readonly ILogger logger;

			bool sairMenu = false;

			ConsoleKeyInfo cki;
		    do
		    {
				menu.Mostrar();
				cki = Console.ReadKey();
			    if(cki.Key == ConsoleKey.D1) 
			    {
			      	//Console.Write("Opcao 1");
			      	logger.Log("Opcao 1");
			      	usarCalculadora.Mostrar();
			    }   
			    else if(cki.Key == ConsoleKey.D2) 
			    {
			        //Console.Write("opcao 2");
			        logger.Log("opcao 2"); 
					menuLivroDB.MenuLivro();
				}
				else if(cki.Key == ConsoleKey.D3) 
			    {
			        //Console.Write("opcao 2");
			        logger.Log("opcao 3"); 
					// connection.TestStringMySQL();
					menuClienteDB.MenuCliente();
				}
			    else if(cki.Key == ConsoleKey.D9 || cki.Key == ConsoleKey.Escape) 
			    {
			        logger.Log("Opcao 9 - Sair");
			        sairMenu = true;
			    }
				else 
				{
					erroMenu.Mostrar(cki.Key.ToString());
				}
			         
		    } while (!sairMenu);
	
			sairPrograma.Mostrar();
		}
	}

}