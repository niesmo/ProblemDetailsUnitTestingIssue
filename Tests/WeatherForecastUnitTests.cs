using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTestingProblemDetails.Controllers;
using UnitTestingProblemDetails.Services;
using Xunit;

namespace Tests
{
    public class WeatherForecastUnitTests
    {
        private readonly Mock<IWeatherForecastService> mockWeatherForecastService;
        private readonly Mock<ILogger<WeatherForecastController>> mockLogger;

        public WeatherForecastUnitTests()
        {
            mockWeatherForecastService = new Mock<IWeatherForecastService>();
            mockLogger = new Mock<ILogger<WeatherForecastController>>();
        }

        [Fact]
        public void WeatherForecastHandlesExceptions()
        {
            // Arrange
            const string exception_message = "let's focus on the future";
            var mockWeatherForecastService = new Mock<IWeatherForecastService>();
            mockWeatherForecastService
                .Setup(s => s.Forecast(It.Is<int>(d => d < 1)))
                .Throws(new ArgumentOutOfRangeException(exception_message));
            var controller = new WeatherForecastController(mockLogger.Object, mockWeatherForecastService.Object);

            // Act
            var response = controller.GetWeatherForecast(-1);

            // Assert
            var result = Assert.IsAssignableFrom<ProblemDetails>(response.Result);
            Assert.Equal(exception_message, result.Detail);
        }
    }
}
