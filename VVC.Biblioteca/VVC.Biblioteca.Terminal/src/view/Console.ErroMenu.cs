namespace VVC.Biblioteca.Terminal{

    public class ErroMenu
    {
            public void Mostrar(string varTecla="")
            {
                    //Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(10, 9);
                    Console.WriteLine("╔════════════════════╗");
                    Console.SetCursorPosition(10, 10);
                    Console.WriteLine("║    " + varTecla);
                    Console.SetCursorPosition(31, 10);
                    Console.WriteLine("║");
                    Console.SetCursorPosition(10, 11);
                    Console.WriteLine("║   Opção invalida   ║");
                    Console.SetCursorPosition(10, 12);
                    Console.WriteLine("║  Retornar ao menu  ║");
                    Console.SetCursorPosition(10, 13);
                    Console.WriteLine("╚════════════════════╝");
                    Console.ResetColor();
                    Console.ReadKey(true);  
            }
    }
}

