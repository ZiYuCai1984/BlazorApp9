using System.Threading;
using System.Threading.Tasks;

namespace ZiYuCai1984.Blog.DocumentIndex.Proxy.Abstractions
{
    public interface ISampleData
    {
        Task<WeatherForecast[]> GetWeatherForecasts(CancellationToken token = default);
    }
}