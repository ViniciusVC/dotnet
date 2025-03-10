using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase // Esta clase deve herdar de ControllerBase.
    {

        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        
        /// <summary>
        /// Testar API. Retorna um "OK".
        /// </summary>        
        [HttpGet("teste")]
        public IActionResult TestaAPI()
        {
            return Ok("OK - API funcionando");
        }


        /// <summary>
        /// Cadastro de filmes, validado no model.
        /// </summary>
        /// <param name="filme">JSON com dados de Filmes{Titulo,Genero,Duracao}</param>
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            /*
                // Validação está no MODEL
                if(!string.IsNullOrEmpty(filme.titulo) &&
                    filme.titulo.Length <= 500 &&
                   !string.IsNullOrEmpty(filme.genero) &&
                   filme.duracao >= 70
                )
            */
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine("Titulo: "+filme.Titulo);
            Console.WriteLine("Genero: "+filme.Genero);
            Console.WriteLine("Duracao: "+filme.Duracao);
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
        }


        /// <summary>
        /// Buscar filmes com paginação.
        /// </summary>
        /// <returns>Retorna os filmes paginados.</returns>
        /// <param name="skip">Int - Iniciar em...</param>
        /// <param name="take">Int - Itens por busca.</param>
        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery]int take = 50)
        {
            var filme = filmes.Skip(skip).Take(take);
            return filme;
        }


        
        /// <summary>
        /// Busca um registro por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna apenas um registro de filme especifico.</returns>
        [HttpGet("id/{id}")]
        public Filme? RecuperaFilmeId(int id)
        {
            return filmes.FirstOrDefault(filme => filme.Id == id); 
        }
         

        /// <summary>
        /// Busca um registro por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna apenas um registro de filme especifico.</returns>
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            var filme = filmes.FirstOrDefault(filme => filme.Id == id); 
            if (filme == null)
            {
                return NotFound("Filme não encontrado");
            }
            else
            {
                return Ok(filme);
            }
        }

    }
}
