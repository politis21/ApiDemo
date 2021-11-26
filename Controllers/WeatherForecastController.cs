using ApiDemo.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<string> SummariesTest = new List<string>
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<string> Nebulosities = new List<string>
        {
        "Cloudy", "Normal", "Shiny"
        };

        private static readonly List<WeatherForecast> WeatherForecasts = new List<WeatherForecast>()
        {
            new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = 21,
                Summary = Summaries[4],
                Nebulosity = Nebulosities[1],
                Moisture = 0.6,
            },
            new WeatherForecast()
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = 30,
                Summary = Summaries[5],
                Nebulosity = Nebulosities[2],
                Moisture = 0.7,
            },
            new WeatherForecast()
            {
                    Date = DateTime.Now.AddDays(-1),
                    TemperatureC = -15,
                    Summary = Summaries[0],
                    Nebulosity = Nebulosities[0],
                    Moisture = 0.9,
            },
            new WeatherForecast()
            {
                    Date = DateTime.Now.AddDays(2),
                    TemperatureC = 35,
                    Summary = Summaries[6],
                    Nebulosity = Nebulosities[2],
                    Moisture = 0.6,
            }
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecasts")]//Annotation που δηλώνει τι ειδους κλήση δέχεται η συγκεκριμένη μέθοδος!
        public IEnumerable<WeatherForecast> Get() //IEnumerable: Κληρονομούν λειτουργικότητές του οι Λίστες και οι Πίνακες. 
        {

            var forecastsList = new List<WeatherForecast>();

            var firstForecast = new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = 21,
                Summary = Summaries[4],
                Nebulosity = Nebulosities[1],
                Moisture = 0.6,
            };

            var secondForecast = new WeatherForecast()
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = 30,
                Summary = Summaries[5],
                Nebulosity = Nebulosities[2],
                Moisture = 0.7,
            };

            var thirdForecast = new WeatherForecast()
            {
                Date = DateTime.Now.AddDays(-1),
                TemperatureC = -15,
                Summary = Summaries[0],
                Nebulosity = Nebulosities[0],
                Moisture = 0.9,
            };

            var fourthForecast = new WeatherForecast()
            {
                Date = DateTime.Now.AddDays(2),
                TemperatureC = 35,
                Summary = Summaries[6],
                Nebulosity = Nebulosities[2],
                Moisture = 0.6,
            };

            forecastsList.Add(firstForecast);
            forecastsList.Add(secondForecast);
            forecastsList.Add(thirdForecast);
            forecastsList.Add(fourthForecast);

            return forecastsList;
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();

        }

        //GET, POST, PUT, DELETE 
        //todo:
        //Βάλε και άλλα properties στο model WeatherForecast
        //Βάλε και άλλες προβλέψεις στη λίστα 
        //Να φτιάξεις μια μέθοδο GetWarmForecasts που θα επιστρέφει μόνο 
        //τις προβλέψεις με θερμοκρασία πάνω από 20οC.

        [HttpGet(Name = "GetWarmForecasts")]
        public IEnumerable<WeatherForecast> GetWarm()
        {
            var forecastsList = WeatherForecasts;

            var warmForecastsList = new List<WeatherForecast>();

            foreach (WeatherForecast forecast in forecastsList)
            {
                if (forecast.TemperatureC > 20)
                {
                    warmForecastsList.Add(forecast);
                }
            }
            return warmForecastsList;

        }

        [HttpGet(Name = "GetForecastsByTemperature")]
        public IEnumerable<WeatherForecast> GetForecastsByTemperature(int temperature)
        {
            var forecastsList = WeatherForecasts;

            var forecastsByTemperatureList = new List<WeatherForecast>();

            foreach (WeatherForecast forecast in forecastsList)
            {
                if (forecast.TemperatureC > temperature)
                {
                    forecastsByTemperatureList.Add(forecast);
                }
            }

            forecastsByTemperatureList = forecastsList.Where(f => f.TemperatureC > temperature).ToList();
            return forecastsByTemperatureList;
            //return WeatherForecasts.Where(f => f.TemperatureC > temperature);
            //2h lysi
        }

        //Μια μέθοδο get που επιστρέφει την πρόβλεψη με τη χαμηλότερη θερμοκρασία
        //Μία μέθοδο get που επιστρέφει τις προβλέψεις που το Summary τους περιέχει το γράμμα που θα παίρνει η μέθοδος ως παράμετρο.
        //Τα παραπάνω να γίνουν  σε ένα νέο branch με όνομα get-methods
        //Sql Server Management Studio

        [HttpGet(Name = "GetMinForecast")]
        public WeatherForecast GetMinForecast()
        {
            var forecastsList = WeatherForecasts;
            int minTemperatureC = forecastsList.Min(f => f.TemperatureC);
            int minForecastIndex = forecastsList.FindIndex(i => i.TemperatureC == minTemperatureC); 
            return forecastsList[minForecastIndex];
        }

        [HttpGet(Name = "GetForecastsBySummary")]
        public IEnumerable<WeatherForecast> GetForecastsBySummary(string letter)
        {
            var forecastsList = WeatherForecasts;

            var forecastsBySummaryList = new List<WeatherForecast>();

            foreach (WeatherForecast forecast in forecastsList)
            {
                if (forecast.Summary != null && forecast.Summary.Contains(letter))
                {
                    forecastsBySummaryList.Add(forecast);
                }
            }

            return forecastsBySummaryList;

        }
        
    }

}
//Value types / reference types c#  (int->value string->reference)
//HTPP methods get put post delete