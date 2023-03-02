using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Weather_MVC.Models;
using Weather_MVC.OpenWeatherMap_Model;
using Weather_MVC.Repositories;

namespace Weather_MVC.Controllers
{
    public class HomeController : Controller
    {


        private readonly IWForecastRepository WForecastRepository;

        public HomeController(IWForecastRepository wForecastRepository)
        {
            WForecastRepository = wForecastRepository;
        }

             [HttpGet]

        public IActionResult SearchByCity()
        {
            var viewModel = new SearchByCity();
            return View(viewModel);
        }
        public IActionResult SearchByCity(SearchByCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Home", new { city = model.CityName });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = new WeatherResponse();
            weatherResponse = WForecastRepository.GetForecast(city);
            
            City viewModel = new City();
            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Temperature = weatherResponse.Main.Temp;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;

            }
            return View(viewModel);

        }

        public IActionResult Index()
        {
            return View();
        }

    }
}