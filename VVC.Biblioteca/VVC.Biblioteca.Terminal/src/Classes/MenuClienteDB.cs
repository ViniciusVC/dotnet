
namespace VVC.Biblioteca.Terminal{

class MenuClienteDB
{
    //static void Menu(string[] args)
    public void MenuCliente()
    {
        // Instanciar UI do menu.
        Menu menu = new Menu(); 
        ClienteController clienteController = new ClienteController();
		Connection connection = new Connection();
        ErroMenu erroMenu = new ErroMenu();

        bool sairMenu = false;
        ConsoleKeyInfo cki;
		do
		{
			menu.MostrarCliente();
			cki = Console.ReadKey();
			    if(cki.Key == ConsoleKey.D1) 
			    {
			      	clienteController.ListarClientes();
			    }   
			    else if(cki.Key == ConsoleKey.D2) 
			    {
			       clienteController.CriarCliente();
				}
				else if(cki.Key == ConsoleKey.D3) 
			    {
			        clienteController.EditarCliente();
				}
				else if(cki.Key == ConsoleKey.D4)
			    {
			        clienteController.DeletarCliente();
				}
				else if(cki.Key == ConsoleKey.D5) 
			    {
			        connection.TestStringMySQL();
				}
			    else if(cki.Key == ConsoleKey.D6 || cki.Key == ConsoleKey.Escape) 
			    {
			        Console.WriteLine("Voltar a home.");
			        sairMenu = true;
			    }
				else 
				{
					erroMenu.Mostrar(cki.Key.ToString());
				}
		} while (!sairMenu);

    }
}
}