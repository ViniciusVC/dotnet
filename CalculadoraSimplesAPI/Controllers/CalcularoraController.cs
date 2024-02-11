using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraSimplesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraSimplesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalcularoraController : ControllerBase
    {
        [HttpGet]
        public ActionResult Test(){
            return Ok("API funcionando.");
        }

        [HttpGet("Somarota/{valor1}/{valor2}")]
        public ActionResult<double> Somarota(double valor1, double valor2){
            return Ok(valor1+valor2);
        }

        [HttpGet("Somar")]
        public ActionResult<Calculadora> Somar(double valor1, double valor2){
            var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            calc.somar();
            return Ok(calc);
        }

        [HttpGet("Subtrair")]
        public ActionResult<Calculadora> Subtrair(double valor1, double valor2){
            var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            calc.subtrair();
            return Ok(calc);
        }
        

        [HttpGet("Multiplicar")]
        public ActionResult<Calculadora> Multiplicar(double valor1, double valor2){
            var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            calc.multiplicar();
            return Ok(calc);
        }

        [HttpGet("Dividir")]
        public ActionResult<Calculadora> Dividir(double valor1, double valor2){
            var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            calc.dividir();
            return Ok(calc);
        }
        
    }
}