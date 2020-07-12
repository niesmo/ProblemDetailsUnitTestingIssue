using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestingProblemDetails.Services
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> Forecast(int numberOfDays);
    }
}
