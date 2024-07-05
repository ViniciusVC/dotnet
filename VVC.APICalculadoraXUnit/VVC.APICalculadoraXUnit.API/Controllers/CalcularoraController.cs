//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using VVCAPICalculadoraXUnit.Models;
using Microsoft.AspNetCore.Mvc;  

namespace VVCAPICalculadoraXUnit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalcularoraController : ControllerBase
    {
        [HttpGet]
        public ActionResult Test(){
            Console.WriteLine("[Metodo Get] /api/calculadora");
            return Ok("API funcionando. ");  // Retorno da requisião.
        }

        [HttpGet("Somarota/{valor1}/{valor2}")]
        public ActionResult<double> Somarota(double valor1, double valor2){
            // Este endpoint não usa nenhuma entidade.
            Console.WriteLine("[Metodo Get] /api/calculadora/Somarota/valor1/valor2");
            return Ok(valor1+valor2);  // Retorno da requisião.
        }

        [HttpGet("Somar")]
        public ActionResult<Calculadora> Somar(double valor1, double valor2){
            Console.WriteLine("[Metodo Get] /api/calculadora/Somar");
            var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            calc.Somar(); // Metodo somar da entidade calculadora.
            return Ok(calc);  // Retorno da requisião.
        }

        [HttpGet("Subtrair")]
        public ActionResult<Calculadora> Subtrair(double valor1, double valor2){
            Console.WriteLine("[Metodo Get] /api/calculadora/Subtrair");
            var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            calc.Subtrair(); // Metodo subtrair da entidade calculadora.
            return Ok(calc);  // Retorno da requisião.
        }
        

        [HttpGet("Multiplicar")]
        public ActionResult<Calculadora> Multiplicar(double valor1, double valor2){
            Console.WriteLine("[Metodo Get] /api/calculadora/Subtrair");
            var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            calc.Multiplicar(); // Metodo multiplicar da entidade calculadora.
            return Ok(calc); // Retorno da requisião.
        }

        [HttpGet("Dividir")]
        public ActionResult<Calculadora> Dividir(double valor1, double valor2){
            Console.WriteLine("[Metodo Get] /api/calculadora/Subtrair");
            var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            calc.Dividir(); // Metodo dividir da entidade calculadora.
            return Ok(calc);  // Retorno da requisião.
        }
        
    }
}