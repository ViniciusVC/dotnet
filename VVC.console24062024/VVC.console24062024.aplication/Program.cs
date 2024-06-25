using System; //Manipular sitema operacional.
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq; // ṕara trabalhar com grande Conjunto de dados.
using System.Text; // Manipular texto.
using System.Threading.Tasks; // Processos paralelos (usa nucleos separados).


namespace Console24062024
{
    class Program
    {
    	// O metodo Main é o primeiro que é execuado.
		static void Main(string[] args)
		{
			
			// Instancia classes
			Menu menu = new Menu(); 
			UsarCalculadora usarCalculadora = new UsarCalculadora();
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

			    if(cki.Key == ConsoleKey.Escape){
			    }
			    else if(cki.Key == ConsoleKey.D1) 
			    {
			      	//Console.Write("Opcao 1");
			      	logger.Log("Opcao 1");
			      	usarCalculadora.Mostrar();
			    }   
			    else if(cki.Key == ConsoleKey.D2) 
			    {
			        //Console.Write("opcao 2");
			        logger.Log("opcao 2"); 
			    }
			    else if(cki.Key == ConsoleKey.D3 || cki.Key == ConsoleKey.Escape) 
			    {
			        logger.Log("Opcao 3 - Sair");
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