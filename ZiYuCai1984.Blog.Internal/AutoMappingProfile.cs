using AutoMapper;
using AutoMapper.EquivalencyExpression;
using ZiYuCai1984.Blog.DocumentIndex.Proxy.Abstractions;

namespace ZiYuCai1984.Blog.Internal
{
    public class AutoMappingProfile : Profile
    {
        // ReSharper disable once EmptyConstructor
        public AutoMappingProfile()
        {
            this.CreateMap<Document, Document>()
                .EqualityComparison((source, dest) => source.Id == dest.Id);

            this.CreateMap<WeatherForecast, WeatherForecast>()
                .EqualityComparison((source, dest) => source.City == dest.City);
        }
    }
}