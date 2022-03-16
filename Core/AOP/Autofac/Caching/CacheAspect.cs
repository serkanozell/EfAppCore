using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Caching;
using Core.Interceptors;
using Core.IoC;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Core.AOP.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        ICacheManager _cacheManager;
        int _duration;

        public CacheAspect(int duration = 10)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var metotName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{metotName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
