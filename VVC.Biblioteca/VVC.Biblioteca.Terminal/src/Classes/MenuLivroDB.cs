
namespace VVC.Biblioteca.Terminal{

class MenuLivroDB
{
    //static void Menu(string[] args)
    public void MenuLivro()
    {
        // Instanciar UI do menu.
        Menu menu = new Menu(); 
        LivroController livroController = new LivroController();
		Connection connection = new Connection();
        ErroMenu erroMenu = new ErroMenu();

        bool sairMenu = false;
        ConsoleKeyInfo cki;
		do
		{
			menu.MostrarLivro();
			cki = Console.ReadKey();
			    if(cki.Key == ConsoleKey.D1) 
			    {
			      	livroController.ListarLivros();
			    }   
			    else if(cki.Key == ConsoleKey.D2) 
			    {
			       livroController.CriarLivro();
				}
				else if(cki.Key == ConsoleKey.D3) 
			    {
			        livroController.EditarLivro();
				}
				else if(cki.Key == ConsoleKey.D4)
			    {
			        livroController.DeletarLivro();
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