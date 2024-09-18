using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
//using VVCAngularAppAspNet1.Server.Models;

namespace VVCAngularAppAspNet1.Server.Controllers   
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiCalcController : ControllerBase
    {
        [HttpGet(Name = "TestApiCalc")]
        public ActionResult Test()
        {
            Console.WriteLine("[Metodo Get] /. API funcionando.");
            return Ok("API funcionando.");  // Retorno da requisião.
        }

        [HttpGet("Somarota/{valor1}/{valor2}", Name = "GetSomaRota")]
        public ActionResult<double> Somarota(double valor1, double valor2)
        {
            // Este endpoint não usa nenhuma entidade.
            Console.WriteLine("[Metodo Get] /Somarota/valor1/valor2");
            return Ok(valor1 + valor2);  // Retorno da requisião.
        }

        [HttpGet("Somar", Name = "GetSomar")]
        public ActionResult<Calculadora> Somar(double valor1, double valor2)
        {
            Console.WriteLine("[Metodo Get] /Somar");
            var calc = new Calculadora(valor1, valor2); // O construtor recebe 2 parametros.
            calc.somar(); // Metodo somar da entidade calculadora.
            return Ok(calc);  // Retorno da requisião.
        }

        [HttpGet("Subtrair", Name = "GetSubtrair")]
        public ActionResult<Calculadora> Subtrair(double valor1, double valor2)
        {
            Console.WriteLine("[Metodo Get] /Subtrair");
            var calc = new Calculadora(valor1, valor2); // O construtor recebe 2 parametros.
            calc.subtrair(); // Metodo subtrair da entidade calculadora.
            return Ok(calc);  // Retorno da requisião.
        }


        [HttpGet("Multiplicar", Name = "GetMultiplicar")]
        public ActionResult<Calculadora> Multiplicar(double valor1, double valor2)
        {
            Console.WriteLine("[Metodo Get] /Subtrair");
            var calc = new Calculadora(valor1, valor2); // O construtor recebe 2 parametros.
            calc.multiplicar(); // Metodo multiplicar da entidade calculadora.
            return Ok(calc); // Retorno da requisião.
        }

        [HttpGet("Dividir", Name = "GetDividir")]
        public ActionResult<Calculadora> Dividir(double valor1, double valor2)
        {
            Console.WriteLine("[Metodo Get] /Subtrair");
            var calc = new Calculadora(valor1, valor2); // O construtor recebe 2 parametros.
            calc.dividir(); // Metodo dividir da entidade calculadora.
            return Ok(calc);  // Retorno da requisião.
        }

    }
}