using Microsoft.AspNetCore.Mvc;

namespace HeroesAPI2.Controllers
{
    [ApiController]
    [Route("heroe")]
    public class WeatherForecastController : ControllerBase
    {
        private List<Heroe> heroes = new List<Heroe>
        {
            new Heroe { Id= 1,
                Nombre="Aquaman",
                Bio="El poder más reconocido de Aquaman es la capacidad telepática para comunicarse con la vida marina, la cual puede convocar a grandes distancias.",
                Img="assets/img/aquaman.png",
                Aparicion="1941-11-01",
                Casa="DC"
            },
              new Heroe { Id= 2,
                Nombre="Batman",
                Bio="Los rasgos principales de Batman se resumen en «destreza física, habilidades deductivas y obsesión». La mayor parte de las características básicas de los cómics han variado por las diferentes interpretaciones que le han dado al personaje.",
                Img="assets/img/batman.png",
                Aparicion="1981-11-01",
                Casa="DC"
            },
            new Heroe { Id= 3,
                Nombre="Thor",
                Bio="Los rasgos principales de Batman se resumen en «destreza física, habilidades deductivas y obsesión». La mayor parte de las características básicas de los cómics han variado por las diferentes interpretaciones que le han dado al personaje.",
                Img="assets/img/thor.png",
                Aparicion="1981-11-01",
                Casa="Marvel"
            }

        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("listar")]
        public List<Heroe> Get()
        {
            return heroes;

        }
        [HttpGet("obtener/{id}")]
        public Heroe ObtenerPorId(int id)
        {
            return heroes.FirstOrDefault(x => x.Id == id);
        }
        [HttpGet("obtener-por-nombre/{termino}")]
        public List<Heroe> ObtenerPorTermino(string termino)
        {
            return heroes.Where(x => x.Nombre.ToLower().Contains(termino.ToLower())).ToList();
        }
        [HttpPost("obtener-por-casa/{casa}")]
        public List<Heroe> ObtenerPorCasa(string casa)
        {
            return heroes.Where(x => x.Casa.ToLower().Contains(casa.ToLower())).ToList();
        }
    }
}