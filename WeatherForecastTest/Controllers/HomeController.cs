using Microsoft.AspNetCore.Mvc;
using WeatherForecastTest.Service;


namespace WeatherForecastTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherInterface _weatherService;
        public HomeController(IWeatherInterface weatherService)
        {
            _weatherService = weatherService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetWeatherForecast(string cityName)
        {
            try
            {
                var weatherForecast = await _weatherService.GetWeatherForecastAsync(cityName);
                return View("WeatherForecast", weatherForecast);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
