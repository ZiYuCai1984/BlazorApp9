using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper.EquivalencyExpression;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ZiYuCai1984.Blog.Internal.Aggregator;

namespace ZiYuCai1984.Blog.Internal
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});


            builder.Services.AddAutoMapper(
                cfg =>
                {
                    cfg.AddCollectionMappers();
                    cfg.AddProfile<AutoMappingProfile>();
                });

            ServicesRegister.Init(builder.Services);
            await builder.Build().RunAsync();
        }
    }
}