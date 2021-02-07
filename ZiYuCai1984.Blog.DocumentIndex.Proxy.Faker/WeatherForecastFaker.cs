using System;
using System.Collections.Generic;
using Bogus;
using ZiYuCai1984.Blog.DocumentIndex.Proxy.Abstractions;

namespace ZiYuCai1984.Blog.DocumentIndex.Proxy.Faker
{
    public class WeatherForecastFaker : Faker<WeatherForecast>
    {
        public WeatherForecastFaker(int maxCount = 50)
        {
            this.MaxCount = maxCount;
            this.MinCount = maxCount / 2;

            var failCount = 0;

            while (this.CityCollection.Count < maxCount)
            {
                var c = FakerHub.Address.City();

                if (!this.CityCollection.Contains(c))
                {
                    this.CityCollection.Add(c);
                    failCount = 0;
                }
                else
                {
                    if (++failCount > 10)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            // ReSharper disable VirtualMemberCallInConstructor
            this.RuleFor(
                w => w.City,
                f =>
                {
                    var c = f.PickRandom(this.Temp);
                    this.Temp.Remove(c);
                    return c;
                });

            this.RuleFor(w => w.Summary, f => f.Lorem.Sentence());
            this.RuleFor(w => w.TemperatureC, f => f.Random.Number(-50, 50));
            this.RuleFor(w => w.Date, f => DateTime.Now);
        }


        private IList<string> Temp { get; set; } = new List<string>();

        private int MinCount { get; }

        private int MaxCount { get; }

        private IList<string> CityCollection { get; } = new List<string>();


        public List<WeatherForecast> GenerateItems()
        {
            this.Temp = new List<string>(this.CityCollection);
            return base.Generate(FakerHub.Random.Int(this.MinCount, this.MaxCount));
        }
    }
}