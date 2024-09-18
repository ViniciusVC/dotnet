// Rotas da API

using Microsoft.AspNetCore.Mvc;

namespace VVCAngularAppAspNet1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("api/[controller]")]
    //[Route("WeatherForecast/[controller]")]


    public class WeatherForecastController : ControllerBase
    {

        // Definindo sumario
        private static readonly string[] Summaries = new[]
        {
            "Congelante", "Revigorante", "Frio", "Fresco", "Suave", "Morno", "Ameno", "Quente", "Abafado", "Escaldante"
        };


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        /* 
         * (IEnumerable = ou tipos semelhantes)
         * IEnumerable 
         * É uma interface que define uma coleção que pode ser iterada. 
         * Quando você retorna IEnumerable<T>, está basicamente indicando que sua ação retorna uma lista de itens do tipo T.
         */

        [HttpGet(Name = "GetPrevisaoDoTempo")]
        public IEnumerable<WeatherForecast> Get(){
   
            Console.WriteLine("[Metodo Get] /WeatherForecast/");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /*
        * ActionResult
        * É um tipo de retorno que permite maior flexibilidade no que sua ação pode retornar. 
        * Com ActionResult, você pode retornar diferentes tipos de respostas HTTP, 
        * como códigos de status, objetos serializados, redirecionamentos, etc.
        * Oferece mais flexibilidade para retornar diferentes tipos de respostas e códigos de status, 
        * tornando-o mais adequado para ações que podem precisar retornar erros ou resultados diferentes com base em condições específicas.
        */

        [HttpGet("Test", Name = "GetTest")]
        public ActionResult test()
        {
            Console.WriteLine("[Metodo Get] /WeatherForecast/test/");

            return Ok("API funcionando.");  // Retorno da requisião.
        }
        
    }
}
