//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using VVCAPICalculadoraXUnit.API.Service;
using VVCAPICalculadoraXUnit.API.Models;
using Microsoft.AspNetCore.Mvc;  

namespace VVCAPICalculadoraXUnit.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalcularoraController : ControllerBase
    {
        /// <summary> Endpoint raiz da api, para verificar se a API esta de pe. </summary>
        /// <returns> Retorna uma mensagem "API funcionando.". </returns>
        [HttpGet]
        public ActionResult Test(){
            Console.WriteLine("[Metodo Get] /api/calculadora");
            return Ok("API funcionando.");  // Retorno da requisião.
        }

        /// <summary> Endpoint de soma. </summary>
        /// <param name="valor1">Numero double. Primeiro numero a ser somado. </param>
        /// <param name="valor2">Numero double. Segundo numero a ser somado. </param>
        /// <returns>Retorna o resultado da soma.</returns>
        [HttpGet("Somarota/{valor1}/{valor2}")]
        public ActionResult<double> Somarota(double valor1, double valor2){
            // Este endpoint não usa nenhuma entidade.
            Console.WriteLine("[Metodo Get] /api/calculadora/Somarota/valor1/valor2");
            return Ok(valor1+valor2);  // Retorno da requisião.
        }

        /// <summary> Endpoint de soma (Usando metodo soma da classe calc). </summary>
        /// <param name="valor1">Numero double. Primeiro numero a ser somado. </param>
        /// <param name="valor2">Numero double. Segundo numero a ser somado. </param>
        /// <returns>Retorna o resultado da soma.</returns>
        [HttpGet("Somar")]
        public ActionResult<CalculadoraModel> Somar(double valor1, double valor2){
            Console.WriteLine("[Metodo Get] /api/calculadora/Somar");
            var calc = new CalculadoraService(valor1,valor2); // O construtor recebe 2 parametros.
            CalculadoraModel retorno = calc.Somar(); // Metodo somar da entidade calculadora.
            return Ok(retorno);  // Retorno da requisião.
        }

        /// <summary> Endpoint de subtrair. </summary>
        /// <param name="valor1">Numero double. Primeiro valor a ser subitraido. </param>
        /// <param name="valor2">Numero double. Segundo valor para subtrair. </param>
        /// <returns>Retorna o resultado da subtracao dos valores.</returns>
        [HttpGet("Subtrair")]
        public ActionResult<CalculadoraModel> Subtrair(double valor1, double valor2){
            Console.WriteLine("[Metodo Get] /api/calculadora/Subtrair");
            var calc = new CalculadoraService(valor1,valor2); // O construtor recebe 2 parametros.
            CalculadoraModel retorno = calc.Subtrair(); // Metodo subtrair da entidade calculadora.
            return Ok(retorno);  // Retorno da requisião.
        }
        
        /// <summary> Endpoint de Multiplicar. </summary>
        /// <param name="valor1">Numero double. Primeiro valor a ser multiplicado. </param>
        /// <param name="valor2">Numero double. Segundo valor para multiplicar. </param>
        /// <returns>Retorna o resultado da multiplicacao dos valores.</returns>
        [HttpGet("Multiplicar")]
        public IActionResult Multiplicar(double valor1, double valor2){
        //public ActionResult<CalculadoraModel> Multiplicar(double valor1, double valor2){
            Console.WriteLine("[Metodo Get] /api/calculadora/Subtrair");
            var calc = new CalculadoraService(valor1,valor2); // O construtor recebe 2 parametros.
            CalculadoraModel retorno = calc.Multiplicar(); // Metodo multiplicar da entidade calculadora.
            return Ok(retorno); // Retorno da requisião.
        }

        /// <summary> Endpoint Dividir. </summary>
        /// <param name="valor1">Numero double. Primeiro valor a ser diviido. </param>
        /// <param name="valor2">Numero double. Segundo valor para dividir. </param>
        /// <returns>Retorna o resultado da divisao dos valores.</returns>
        [HttpGet("Dividir")]

        
        public IActionResult Dividir(double valor1, double valor2){
        //public ActionResult<CalculadoraModel> Dividir(double valor1, double valor2){
            Console.WriteLine("[Metodo Get] /api/calculadora/Subtrair");
            var calc = new CalculadoraService(valor1,valor2); // O construtor recebe 2 parametros.
            CalculadoraModel retorno = calc.Dividir(); // Metodo dividir da entidade calculadora.
            return Ok(retorno);  // Retorno da requisião.
        }
        
    }
}