
namespace VVC.Biblioteca.Terminal{
	
    public class Menu
    {
            public void Mostrar() {
            	Console.Clear();
				Console.SetCursorPosition(3, 1);
            	Console.WriteLine("╔════════════════════════════════════════╗");
            	Console.SetCursorPosition(3, 2);
				Console.WriteLine("║ SGB - SISTEMA GERENCIMENTO BIBLIOTECA  ║");
				Console.SetCursorPosition(3, 3);
				Console.WriteLine("╚════════════════════════════════════════╝");
				Console.SetCursorPosition(3, 5);
				Console.WriteLine("╔════════════════════════════════════════╗");
				Console.SetCursorPosition(3, 6);
				Console.WriteLine("║  1 - Calculadora                       ║");
				Console.SetCursorPosition(3, 7);
				Console.WriteLine("║  2 - Gerenciar Livros                  ║");
				Console.SetCursorPosition(3, 8);
				Console.WriteLine("║  3 - Gerenciar Clientes                ║");
				Console.SetCursorPosition(3, 9);
				Console.WriteLine("║  4 - Gerenciar Emprestimos             ║");
				Console.SetCursorPosition(3, 10);
				Console.WriteLine("║  9 - sair do programa                  ║");
				Console.SetCursorPosition(3, 11);
				Console.WriteLine("╚════════════════════════════════════════╝");
            }

            public void MostrarLivro() {
            	Console.Clear();
				Console.SetCursorPosition(3, 1);
            	Console.WriteLine("╔════════════════════════════════════════╗");
            	Console.SetCursorPosition(3, 2);
				Console.WriteLine("║     MENU - BANCO DE DADOS - LIVRO      ║");
				Console.SetCursorPosition(3, 3);
				Console.WriteLine("╚════════════════════════════════════════╝");
				Console.SetCursorPosition(3, 5);
				Console.WriteLine("╔════════════════════════════════════════╗");
				Console.SetCursorPosition(3, 6);
				Console.WriteLine("║  1. Lista de livros                    ║");
				Console.SetCursorPosition(3, 7);
				Console.WriteLine("║  2. Cadastro de novo livro             ║");
				Console.SetCursorPosition(3, 8);
				Console.WriteLine("║  3. Editar livro                       ║");
				Console.SetCursorPosition(3, 9);
				Console.WriteLine("║  4. Deletar livro                      ║");
				Console.SetCursorPosition(3, 10);
                Console.WriteLine("║  5. testar conexão com banco de dados. ║");
                Console.SetCursorPosition(3, 11);
				Console.WriteLine("║  6. voltar menu completo               ║");
				Console.SetCursorPosition(3, 12);
				Console.WriteLine("╚════════════════════════════════════════╝");
            }

			public void MostrarCliente() {
            	Console.Clear();
				Console.SetCursorPosition(3, 1);
            	Console.WriteLine("╔════════════════════════════════════════╗");
            	Console.SetCursorPosition(3, 2);
				Console.WriteLine("║    MENU - BANCO DE DADOS - CLIENTE     ║");
				Console.SetCursorPosition(3, 3);
				Console.WriteLine("╚════════════════════════════════════════╝");
				Console.SetCursorPosition(3, 5);
				Console.WriteLine("╔════════════════════════════════════════╗");
				Console.SetCursorPosition(3, 6);
				Console.WriteLine("║  1. Lista de clientes.                 ║");
				Console.SetCursorPosition(3, 7);
				Console.WriteLine("║  2. Cadastro de novo Cliente.          ║");
				Console.SetCursorPosition(3, 8);
				Console.WriteLine("║  3. Editar livro.                      ║");
				Console.SetCursorPosition(3, 9);
				Console.WriteLine("║  4. Excluir cliente.                   ║");
				Console.SetCursorPosition(3, 10);
                Console.WriteLine("║  5. testar conexão com banco de dados. ║");
                Console.SetCursorPosition(3, 11);
				Console.WriteLine("║  6. voltar menu completo               ║");
				Console.SetCursorPosition(3, 12);
				Console.WriteLine("╚════════════════════════════════════════╝");
            }

			public void MostrarEmprestimo() {
            	Console.Clear();
				Console.SetCursorPosition(3, 1);
            	Console.WriteLine("╔════════════════════════════════════════╗");
            	Console.SetCursorPosition(3, 2);
				Console.WriteLine("║   MENU - BANCO DE DADOS - EMPRESTIMO   ║");
				Console.SetCursorPosition(3, 3);
				Console.WriteLine("╚════════════════════════════════════════╝");
				Console.SetCursorPosition(3, 5);
				Console.WriteLine("╔════════════════════════════════════════╗");
				Console.SetCursorPosition(3, 6);
				Console.WriteLine("║                                        ║");
				Console.SetCursorPosition(3, 7);
				Console.WriteLine("║                                        ║");
				Console.SetCursorPosition(3, 8);
				Console.WriteLine("║                                        ║");
				Console.SetCursorPosition(3, 9);
				Console.WriteLine("║                                        ║");
				Console.SetCursorPosition(3, 10);
                Console.WriteLine("║                                        ║");
                Console.SetCursorPosition(3, 11);
				Console.WriteLine("║  6. voltar menu completo               ║");
				Console.SetCursorPosition(3, 12);
				Console.WriteLine("╚════════════════════════════════════════╝");
            }
    }
}

