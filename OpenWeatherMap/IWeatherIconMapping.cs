using System.IO;
using System.Threading.Tasks;
using OpenWeatherMap.Models;

namespace OpenWeatherMap
{
    public interface IWeatherIconMapping
    {
        Task<Stream> GetIconAsync(WeatherCondition weatherCondition);
    }
}