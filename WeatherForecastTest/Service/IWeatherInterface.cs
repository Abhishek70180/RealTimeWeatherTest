using OpenWeatherApplication.Models;

namespace WeatherForecastTest.Service
{
    public interface IWeatherInterface
    {
        Task<WeatherForecast> GetWeatherForecastAsync(string cityName);
    }
}
