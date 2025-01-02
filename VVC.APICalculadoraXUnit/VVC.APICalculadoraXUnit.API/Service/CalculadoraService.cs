using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VVCAPICalculadoraXUnit.API.Models;

namespace VVCAPICalculadoraXUnit.API.Service
{
    
    /// <summary> Classe CalculadoraService instancia CalculadoraModel. </summary>
    public class CalculadoraService
    {
        
 
        private CalculadoraModel calculadoraModel;
        

        /// <summary> Metodo Construor (sem parametros) que nao faz nada quando nao tem parametro. </summary>
        public CalculadoraService()
        {
            calculadoraModel = new CalculadoraModel();
        }

        
        /// <summary> Metodo Construtor em sobrecarga (com parametros). Aplicando valores ao modelo.</summary>
        public CalculadoraService(double valor1, double valor2)
        {
            calculadoraModel = new CalculadoraModel();
            calculadoraModel.valor1 = valor1;
            calculadoraModel.valor2 = valor2;
            calculadoraModel.operadorsimples = "";
            //return calculadoraModel;
        }

        /// <summary> Metodo(Funcao) que calcula a soma. "Calculando a soma." </summary>
        public CalculadoraModel Somar()
        {
            calculadoraModel.operadorsimples = "somar";
            calculadoraModel.resultado = calculadoraModel.valor1+calculadoraModel.valor2;
            return calculadoraModel;
        }

        /// <summary> Metodo(Funcao) que calcula que calcula a subiracao. "Calculando a subiracao." </summary>
        public CalculadoraModel Subtrair()
        {
            calculadoraModel.operadorsimples = "subtrair";
            calculadoraModel.resultado = calculadoraModel.valor1-calculadoraModel.valor2;
            return calculadoraModel;
        }

        /// <summary> Metodo(Funcao) que calcula a divisao. "Calculando a divisao." </summary>
        public CalculadoraModel Dividir()
        {
            calculadoraModel.operadorsimples = "dividir";
            calculadoraModel.resultado = calculadoraModel.valor1/calculadoraModel.valor2;
            return calculadoraModel;
        }

        /// <summary> Metodo(Funcao) que calcula a multiplicacao. "Calculando a multiplicacao." </summary>
        public CalculadoraModel Multiplicar()
        {
            calculadoraModel.operadorsimples = "multiplicar";
            calculadoraModel.resultado = calculadoraModel.valor1*calculadoraModel.valor2;
            return calculadoraModel;
        }

        /// <summary> Metodo(Funcao) que calcula o resto da divisao." </summary>
        public (int quociente, int resto) RestoDivisao(int dividento, int divisor) => (dividento / divisor, dividento % divisor);

    }
}