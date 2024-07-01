//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using CalculadoraSimplesAPI.Models;
using Microsoft.AspNetCore.Mvc;  
using VVC.Biblioteca.API.Repositories;
using VVC.Biblioteca.API.Models;

namespace VVC.Biblioteca.API.UI
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {

        private readonly ILivroRepository _livroRepository;

        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public ActionResult Test(){
            Console.WriteLine("[Metodo Get] /. API funcionando.");
            return Ok("API - VVC Biblioteca - funcionando.");  // Retorno da requisião.
        }

        [HttpGet("listartodos")]
        public ActionResult GetLivros(double valor1, double valor2){
        //public ActionResult<double> Somarota(double valor1, double valor2){
            Console.WriteLine("[Metodo Get] api/livros/listartodos/");
            return Ok("Retorna todos os registros da tabela Livro.");  // Retorno da requisião.
        }

        [HttpGet("listarum/{valor1}")]
        public ActionResult GetLivro(double valor1){
        //public ActionResult<double> Somarota(double valor1, double valor2){
            Console.WriteLine("[Metodo Get] api/livros/listarum/valor1");
            return Ok("Retorna informacao de um Livro (ou Livro não foi encontrado).");  // Retorno da requisião.
        }

        [HttpPost("salvarlivro")]
        public ActionResult PostLivro(double valor1, double valor2){
        //public ActionResult<Calculadora> Somar(double valor1, double valor2){
            Console.WriteLine("[Metodo Post] api/livros/salvarlivro");
            //var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            //calc.somar(); // Metodo somar da entidade calculadora.
            return Ok("Retorna o ID do livro cadastrado (Ou falha ao salvar livro).");  // Retorno da requisião.
        }

        [HttpPut("atualizalivro")]
        public ActionResult PutLivro(double valor1){
        //public ActionResult<Calculadora> Subtrair(double valor1, double valor2){
            Console.WriteLine("[Metodo Put] api/livros/atualizalivro");
            //var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            //calc.subtrair(); // Metodo subtrair da entidade calculadora.
            return Ok("Retorna Livro atualizado (Ou falha ao atualizar livro).");  // Retorno da requisião.
        }
        

        [HttpDelete("apagarlivro")]
        public ActionResult DeleteLivro(double valor1){
        //public ActionResult<Calculadora> Multiplicar(double valor1, double valor2){
            Console.WriteLine("[Metodo Delete] api/livros/apagarlivro");
            //var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            //calc.multiplicar(); // Metodo multiplicar da entidade calculadora.
            return Ok("API funcionando.");  // Retorno da requisião.
        }

        
    }
}