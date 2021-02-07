using System;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using ZiYuCai1984.Blog.DocumentIndex.Proxy.Abstractions;
using ZiYuCai1984.Blog.DocumentIndex.Proxy.Faker;

namespace ZiYuCai1984.Blog.Internal.Aggregator
{
    public static class ServicesRegister
    {
        public static void Init(IServiceCollection serviceCollection)
        {
            Randomizer.Seed = new Random(1963);

            serviceCollection.AddSingleton<IDocumentIndexProxy, DocumentIndexProxy>();
            serviceCollection.AddSingleton<ISampleData, SampleData>();

        }
    }
}