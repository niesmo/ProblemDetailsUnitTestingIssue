using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnitTestingProblemDetails.Services;

namespace UnitTestingProblemDetails.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> GetWeatherForecast(int numberOfDays=5)
        {
            try
            {
                return Ok(_weatherForecastService.Forecast(numberOfDays));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
