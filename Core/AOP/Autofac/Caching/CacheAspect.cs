using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Caching;
using Core.Interceptors;
using Core.IoC;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcern.Caching.Redis;

namespace Core.AOP.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        ICacheManager _redisCache;
        ICacheManager _cacheManager;
        int _duration;

        public CacheAspect(int duration = 5)
        {
            _duration = duration;
            _redisCache = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            //_redisCache = ServiceTool.ServiceProvider.GetService<RedisCache>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var metotName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{metotName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_redisCache.IsAdd(key))
            {
                invocation.ReturnValue = _redisCache.Get(key);
                return;
            }
            invocation.Proceed();
            _redisCache.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
