using System.Threading;
using System.Threading.Tasks;
using ZiYuCai1984.Blog.DocumentIndex.Proxy.Abstractions;

namespace ZiYuCai1984.Blog.DocumentIndex.Proxy.Faker
{
    public class SampleData : ISampleData
    {



        private WeatherForecastFaker WeatherForecastFaker { get; } = new WeatherForecastFaker();

        public Task<WeatherForecast[]> GetWeatherForecasts(CancellationToken token = default)
        {
            return Task.FromResult(this.WeatherForecastFaker.GenerateItems().ToArray());
        }
    }
}