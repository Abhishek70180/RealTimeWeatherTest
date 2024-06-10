using Newtonsoft.Json;
using OpenWeatherApplication.Models;

namespace WeatherForecastTest.Service
{
    public class OpenWeatherMapService : IWeatherInterface
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public OpenWeatherMapService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<WeatherForecast> GetWeatherForecastAsync(string cityName)
        {
            string apiKey = _configuration["OpenWeatherMap:ApiKey"];
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(jsonString);
                return weatherForecast;
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve weather forecast. Plzz check valid name or zip code.");
            }
        }
    }
}
