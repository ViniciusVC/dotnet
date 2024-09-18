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
         * � uma interface que define uma cole��o que pode ser iterada. 
         * Quando voc� retorna IEnumerable<T>, est� basicamente indicando que sua a��o retorna uma lista de itens do tipo T.
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
        * � um tipo de retorno que permite maior flexibilidade no que sua a��o pode retornar. 
        * Com ActionResult, voc� pode retornar diferentes tipos de respostas HTTP, 
        * como c�digos de status, objetos serializados, redirecionamentos, etc.
        * Oferece mais flexibilidade para retornar diferentes tipos de respostas e c�digos de status, 
        * tornando-o mais adequado para a��es que podem precisar retornar erros ou resultados diferentes com base em condi��es espec�ficas.
        */

        [HttpGet("Test", Name = "GetTest")]
        public ActionResult test()
        {
            Console.WriteLine("[Metodo Get] /WeatherForecast/test/");

            return Ok("API funcionando.");  // Retorno da requisi�o.
        }
        
    }
}
