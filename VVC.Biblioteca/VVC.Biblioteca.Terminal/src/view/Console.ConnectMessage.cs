namespace VVC.Biblioteca.Terminal
{
	
    public class ConnectMessage
    {
		
            public void Erro()
            {
                    //Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(10, 7);
                    Console.WriteLine("╔═══════════════════╗");
                    Console.SetCursorPosition(10, 8);
                    Console.WriteLine("║  Erro na conexao  ║");
                    Console.SetCursorPosition(10, 9);
                    Console.WriteLine("╚═══════════════════╝");
                    Console.ResetColor();
                    Console.ReadKey(true);  
            }

            public void Sucesso() {
            	Console.BackgroundColor = ConsoleColor.Blue;
		Console.ForegroundColor = ConsoleColor.Black;
		Console.SetCursorPosition(12, 7);
		Console.WriteLine("╔═══════════════╗");
		Console.SetCursorPosition(12, 8);
		Console.WriteLine("║  Conexão OK.  ║");
		Console.SetCursorPosition(12, 9);
		Console.WriteLine("╚═══════════════╝");
		Console.ResetColor();
		Console.ReadKey(true);
            }
    }
}