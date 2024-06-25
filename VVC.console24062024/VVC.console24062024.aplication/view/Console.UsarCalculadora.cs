namespace Console24062024{

    public class UsarCalculadora
    {
            //public UsarCalculadora()
            public void Mostrar()
            {
                Console.Clear();
                Calculadora calculadora = new Calculadora(); // Instanciando classe Calculadora.
                int a = calculadora.Soma(2,3);
                int b = calculadora.Subtracao(2,3);
                int c = calculadora.Multiplicao(2,3);
                int d = calculadora.Divisao(2,3);
                //Console.CursorSize = 20;
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("2 + 3 = "+a);
                Console.WriteLine("2 - 3 = "+b);
                Console.WriteLine("2 * 3 = "+c);
                Console.WriteLine("2 / 3 = "+d);
                Console.WriteLine("Press any key for return to menu...");
                Console.ReadKey(true);
            }
    }
}

