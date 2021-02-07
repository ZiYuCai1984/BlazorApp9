using System;

namespace ZiYuCai1984.Blog.DocumentIndex.Proxy.Abstractions
{
    public class WeatherForecast
    {
        public string City { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; } = string.Empty;

    }
}