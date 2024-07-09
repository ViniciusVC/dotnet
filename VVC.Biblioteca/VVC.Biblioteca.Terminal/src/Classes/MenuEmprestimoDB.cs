
namespace VVC.Biblioteca.Terminal{

class MenuEmprestimoDB
{
    //static void Menu(string[] args)
    public void MenuEmprestimo()
    {
        // Instanciar UI do menu.
        Menu menu = new Menu(); 
        EmprestimoController emprestimoController = new EmprestimoController();
		Connection connection = new Connection();
        ErroMenu erroMenu = new ErroMenu();

        bool sairMenu = false;
        ConsoleKeyInfo cki;
		do
		{
			menu.MostrarEmprestimo();
			cki = Console.ReadKey();
			    if(cki.Key == ConsoleKey.D1) 
			    {
					//1. listar livros emprestados
			      	emprestimoController.ListarEmprestimos();
			    }   
			    else if(cki.Key == ConsoleKey.D2) 
			    {
					//2. listar livros com um cliente 
			       emprestimoController.BuscarEmprestimos();
				}
				else if(cki.Key == ConsoleKey.D3) 
			    {
					//3. Emprestar livro  
			        emprestimoController.CriarEmprestimo();
				}
				else if(cki.Key == ConsoleKey.D4)
			    {
					// 4. Devolver livro   
			        emprestimoController.DevolverLivro();
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