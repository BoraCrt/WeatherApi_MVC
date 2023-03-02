using Weather_MVC.OpenWeatherMap_Model;

namespace Weather_MVC.Repositories
{
    public interface IWForecastRepository
    {
        WeatherResponse GetForecast(string city);
    }
}
