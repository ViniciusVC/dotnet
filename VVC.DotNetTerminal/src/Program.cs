using System; //Manipular sitema operacional.
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq; // ṕara trabalhar com grande Conjunto de dados.
using System.Text; // Manipular texto.
using System.Threading.Tasks; // Processos paralelos (usa nucleos separados).

/*
Este é o arquivo principal deste projeto.
Projeto DotNet Core do tipo console.

    1º Instalar o SDK do .NET:
    $ sudo apt-get install -y dotnet-sdk-8.0
    2º Crie uma pasta para o projeto:
    $ mkdir projetoteste
    3º Entre na pasta:
    $ cd projetoteste
    4º Iniciei um projeto de terminal:
    $ dotnet new console
    5ª Rodar a aplicação:
    $ dotnet run

*/



namespace ProgramCSharp001
{
    class Program
    {

        enum Cor { Azul, Verde, Amarelo, Vermelho}

        static string nomeDaVariavelGlobal = "Isto é uma variavel Global.";

        static void Main(string[] args){
            // See https://aka.ms/new-console-template for more information

            Console.WriteLine("Hello, World!");


            declaracaoDeVariaveis(); // Função sem parametro.

            string nome = perguntanome(); // Função com retorno.
            Console.WriteLine("Ola "+nome+".");

            tipoDeErro(100); // Função com parametro.

            //Usando o enum
            Cor corfavorita = Cor.Verde;
            // Este enum esta gerando um erro do compulador.

            if(corfavorita == Cor.Amarelo){
                Console.WriteLine("Este texto não será impresso.");
            }

            Console.WriteLine(menu());

            // Instanciar a classe 'classOpcoesDeLoop'
            classOpcoesDeLoop objetoLoop = new classOpcoesDeLoop();
            objetoLoop.functLoopWhile();
            objetoLoop.functLoopForeach();
            objetoLoop.functLoopFor();
 
            /*
            functLoopWhile();
            functLoopForeach();
            functLoopFor();
            */
        }

        static void declaracaoDeVariaveis()
        {
            Console.WriteLine("declaracaoDeVariaveis()");
            
            //Declarar uma variavel
            // Ini (Ex.: -12 ou 3000)
            // Float (Ex.: -15.6f ou 232.132f)
            // bool (Ex.: true ou false)
            // String (Ex.: "sdfsdg sdfg")
            // Char  (Ex.: "a")

            int a;
            a = 10;
            int b = a + 2;

            Console.WriteLine("A variavel a é "+a);
            Console.WriteLine($" A variavel b é {b}");

            //declarando array..
            string[] brinquedos = new string[5] {
                "bola",
                "boneco",
                "boneca",
                "carrinho",
                "dinosauro"
            };
            Console.WriteLine("Item 1 : "+brinquedos[1]);

            // outra forma de declarar o array
            int[] valores = {20,30,40,50};

            Console.WriteLine(nomeDaVariavelGlobal+"\n");

        }


        static string perguntanome()
        {
            Console.WriteLine("perguntanome()");
            Console.WriteLine("Qual o seu nome?");
            string? userImput = Console.ReadLine(); // Use o ponto de interrogação para permitir que a variavel receba null.
            if (userImput=="" || userImput==null){
                userImput="estranho";
            }
            return userImput;
        }

        static void tipoDeErro(int coderro)
        {
            Console.WriteLine("Função tipoDeErro()");
            if(coderro>499){
                Console.WriteLine("Erro no servidor. \n Codigo de erro "+coderro);
            }else if(coderro>399){
                Console.WriteLine("Erro no cliente. \n Aplicação local. Codigo de erro "+coderro);
            }else{
                Console.WriteLine("OK. Sucesso. \n Codigo "+coderro);
            }

        }

        static string menu()
        {
            Console.WriteLine("Selecione a opção desejada:");
            Console.WriteLine("1-Criar\n2-Deletar\n3-Editar\n4-Listar\n5-Atualizar");
            int index = int.Parse(Console.ReadLine());
            //Falta tratamento

            return "terminou menu";
        }

    }

}

