using Microsoft.AspNetCore.Mvc;
using csharp_api.Entities;

// Previsão do tempo.
namespace csharp_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // Criando sumário de temperatura.
        private static readonly string[] Summaries = new[]
        {
            "Congelante", "Revigorante", "Frio", "Fresco", "Suave", "Morno", "Ameno", "Quente", "Abafado", "Escaldante"
        };
    
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //return "ok!!!!!!";
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Recupera o modelo de equipes a partir de um agrupamento e perfil de equipe.
        /// </summary>
        /// <param name="id">Inteiro. Indica qual ID. </param>
        /// <param name="servicos">Inteiro. Indica qual o servicos.</param>
        /// <returns>Retorna uma mensagem contendo um modelo de equipe pertencente ao agrupamento e categoria parametrizados.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Parâmetros inválidos</response>
        [HttpGet("api/operadores/{id}")]
        public IActionResult GetOperador(int id, [FromQuery] int[] servicos)
        {
            // Andpoint que recebe um ID e um array de IDs de serviços.
            return Ok(new { OperadorId = id, Servicos = servicos });
        }

    }
}