namespace VVC.Biblioteca.Terminal{
	
    public class Sair
    {
            public void Mostrar() {
            	Console.BackgroundColor = ConsoleColor.Red;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.SetCursorPosition(8, 10);
				Console.WriteLine("╔════════════════════════════╗");
				Console.SetCursorPosition(8, 11);
				Console.WriteLine("║  Press any key to exit...  ║");
				Console.SetCursorPosition(8, 12);
				Console.WriteLine("╚════════════════════════════╝");
				Console.ResetColor();
				Console.ReadKey(true);
            }
    }
}