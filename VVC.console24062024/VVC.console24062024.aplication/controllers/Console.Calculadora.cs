namespace Console24062024{

    public class Calculadora
    {
            public int Soma(int operador1=0, int operador2=0) {
                return operador1 + operador2;
            }

            public int Subtracao(int operador1=0, int operador2=0)  
            {
                return operador1 - operador2;
            }


            public int Multiplicao(int operador1=0, int operador2=0)
            {
                return operador1 * operador2;
            }

            public int Divisao(int dividento=0, int divisor=1)
            {
                return dividento / divisor;
            }

            public (int quociente, int resto) RestoDivisao(int dividento, int divisor)
            {
                return (dividento / divisor, dividento % divisor);  
            } 
    }

    //interface ICalculadora
    //{
    //
    //}

}

