using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraSimplesAPI.Models
{
    public class Calculadora
    {
        // modelo representativo de dados.

        public double valor1{get;set;} // Propriedade valor1
        public double valor2{get;set;} // Propriedade valor1
        public double resultado{get;set;} // Propriedade Resultado
        public string operadorsimples{get;set;} // Propriedade operador

        public Calculadora()
        {
            // Metodo Construor que não faz nada quando não tem parametro. 
        }

        
        public Calculadora(double valor1, double valor2)
        {
            // Metodo Construtor em sobrecarga
            this.valor1 = valor1;
            this.valor2 = valor2;
            this.operadorsimples = "";
        }


        public void somar()
        {
            // metodo/Funcao que calcula.
            this.operadorsimples = "somar";
            this.resultado = valor1+valor2;
        }

        public void subtrair()
        {
            // metodo/Funcao que calcula.
            this.operadorsimples = "subtrair";
            this.resultado = valor1-valor2;
        }

        public void dividir()
        {
            // metodo/Funcao que calcula.
            this.operadorsimples = "dividir";
            this.resultado = valor1/valor2;
        }

        public void multiplicar()
        {
            // metodo/Funcao que calcula.
            this.operadorsimples = "multiplicar";
            this.resultado = valor1*valor2;
        }

    }
}