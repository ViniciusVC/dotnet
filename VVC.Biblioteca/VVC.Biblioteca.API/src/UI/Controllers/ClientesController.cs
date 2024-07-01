using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;  

using VVC.Biblioteca.API.Repositories;
using VVC.Biblioteca.API.Models;

namespace VVC.Biblioteca.API.UI
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {

        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public ActionResult Test(){
            Console.WriteLine("[Metodo Get] api/clientes/ API funcionando.");
            return Ok("API - VVC Biblioteca - funcionando.");  // Retorno da requisião.
        }


        [HttpGet("listartodos")]
        //public ActionResult GetClientes(){
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes(){
            Console.WriteLine("[Metodo Get] api/clientes/listartodos");
            //return Ok("Retorna todos os registros da tabela Livro.");
            return Ok(await _clienteRepository.Selecionartodos());   // Retorno da requisião.
        }

        [HttpGet("listarumlivro/{valor1}")]
        public ActionResult GetCliente(int id){
            Console.WriteLine("[Metodo Get] api/listarumlivro/valor1");
            return Ok("Retorna informacao de um Cliente (ou Livro não foi encontrado).");  // Retorno da requisião.
        }

        [HttpPost("salvar")]
        public async Task<ActionResult> PostCliente(ClientesController cliente){
            Console.WriteLine("[Metodo Post] api/clientes/salvar");           
             _clienteRepository.Incluir(cliente);
            if(await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente salvo com sucesso.");
            }
            else{
                return BadRequest("falha ao salvar cliente.");
            }
        }

        [HttpPut("atualizalivro")]
        public ActionResult PutCliente(double valor1){
        //public ActionResult<Calculadora> Subtrair(double valor1, double valor2){
            Console.WriteLine("[Metodo Put] api/clientes/atualizalivro");
            return Ok("Retorna Livro atualizado (Ou falha ao atualizar livro).");  // Retorno da requisião.
        }
        

        [HttpDelete("apagarlivro")]
        public ActionResult DeleteCliente(double id){
        //public ActionResult<Calculadora> Multiplicar(double valor1, double valor2){
            Console.WriteLine("[Metodo Delete] api/clientes/apagarlivro");
            //var calc = new Calculadora(valor1,valor2); // O construtor recebe 2 parametros.
            //calc.multiplicar(); // Metodo multiplicar da entidade calculadora.
            return Ok("API funcionando.");  // Retorno da requisião.
        }

        
    }
}