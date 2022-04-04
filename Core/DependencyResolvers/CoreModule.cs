using Core.CrossCuttingConcern.Caching;
using Core.CrossCuttingConcern.Caching.MemoryCache;
using Core.CrossCuttingConcern.Caching.Redis;
using Core.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Core.Implementations;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            var conf = new RedisConfiguration()
            {
                AbortOnConnectFail = true,
                KeyPrefix = "",
                Hosts = new RedisHost[]
                {
                    new RedisHost { Host = "127.0.0.1", Port = 6379 }
                },
                AllowAdmin = true,
                ConnectTimeout = 1000,
                Database = 0,
                ServerEnumerationStrategy = new ServerEnumerationStrategy()
                {
                    Mode = ServerEnumerationStrategy.ModeOptions.All,
                    TargetRole = ServerEnumerationStrategy.TargetRoleOptions.Any,
                    UnreachableServerAction = ServerEnumerationStrategy.UnreachableServerActionOptions.Throw
                }
            };

            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<ICacheManager, MemoryCache>();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<IRedisCacheClient, RedisCacheClient>();
            serviceCollection.AddSingleton<IRedisCacheConnectionPoolManager, RedisCacheConnectionPoolManager>();
            serviceCollection.AddSingleton<ISerializer, NewtonsoftSerializer>();
            serviceCollection.AddSingleton((opt) => opt.GetRequiredService<IRedisCacheClient>().GetDbFromConfiguration());
            serviceCollection.AddSingleton(conf);
            serviceCollection.AddSingleton<ICacheManager>((opt) => { return new RedisCache(opt.GetRequiredService<IRedisCacheClient>()); });
            //serviceCollection.AddSingleton<IRedisCacheClient, RedisCacheClient>();
            serviceCollection.AddSingleton<ICacheManager, RedisCache>();

        }
    }
}
