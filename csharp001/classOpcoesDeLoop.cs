using System; //Manipular sitema operacional.
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq; // ṕara trabalhar com grande Conjunto de dados.
using System.Text; // Manipular texto.
//using System.Threading.Tasks; // Processos paralelos (usa nucleos separados).


namespace ProgramCSharp001
{

    public class classOpcoesDeLoop
    {
        // Propriedade da classe são as variaveis.
        private string[] nomes = {"Vini","Biel","Lipe","Luli","Lane"};
            

        public classOpcoesDeLoop(){
            // O metodo construtor tem o mesmo nome da classe
            Console.WriteLine("\nInstanciou a classe Opcoes De Loop.");
        }

        // Metodos da classe são equivalente a funções.
        public void functLoopWhile()
        {
            int contador = 0;
            Console.WriteLine("\nInicio loop while.");
            while(contador <10){
                Console.WriteLine("contador="+contador);
                //contador = contador + 1;
                //contador += 1;
                contador++;
            }
            Console.WriteLine("Fim do loop while.\n");    
        }
         
        public void functLoopForeach()
        {
            Console.WriteLine("\nInicio loop foreach.");
            foreach(string apelido in nomes)
            {
                Console.WriteLine("apelido="+apelido);
            }
            Console.WriteLine("Fim do loop foreach.\n");    
        }

        public void functLoopFor()
        {
            Console.WriteLine("\nInicio loop for.");
            for(int contador = 0; contador<nomes.Length; contador++)
            {
                Console.WriteLine(contador + "-" +nomes[contador]);
            }
            Console.WriteLine("Fim do loop for.\n");    
        }

        ~classOpcoesDeLoop(){
            // O metodo destrutor inicia com o ~
            Console.WriteLine("\nObjeto jogado fora.");
        }

    }
}