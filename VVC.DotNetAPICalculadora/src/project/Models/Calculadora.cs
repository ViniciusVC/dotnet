using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CalculadoraSimplesAPI.Models
{
    // Esta entidade Calculadora não realmente um modelo de dados.
    public class Calculadora
    {
        
        // (Propriedades da entidade) Modelo representativo de dados.
        public double valor1{get;set;} // Propriedade valor1
        public double valor2{get;set;} // Propriedade valor1
        public double resultado{get;set;} // Propriedade Resultado
        public string? operadorsimples{get;set;} // Propriedade operador

        public Calculadora()
        {
            // Metodo Construor (sem parametros) que não faz nada quando não tem parametro.
        }

        
        public Calculadora(double valor1, double valor2)
        {
            // Metodo Construtor em sobrecarga (com parametros). 
            // Aplicando valores.
            this.valor1 = valor1;
            this.valor2 = valor2;
            this.operadorsimples = "";
        }


        public void somar()
        {
            // metodo(Funcao) que calcula a soma.
            // "Calculando a soma."
            this.operadorsimples = "somar";
            this.resultado = valor1+valor2;
        }

        public void subtrair()
        {
            // metodo(Funcao) que calcula que calcula a subiração.
            // "Calculando a subiração."
            this.operadorsimples = "subtrair";
            this.resultado = valor1-valor2;
        }

        public void dividir()
        {
            // metodo(Funcao) que calcula a divisão.
            // "Calculando a divisão."
            this.operadorsimples = "dividir";
            this.resultado = valor1/valor2;
        }

        public void multiplicar()
        {
            // metodo(Funcao) que calcula a multiplicação.
            // "Calculando a multiplicação."
            this.operadorsimples = "multiplicar";
            this.resultado = valor1*valor2;
        }

    }
}