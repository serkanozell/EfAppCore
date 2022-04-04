using Core.IoC;
using Core.Results;
using DataAccess.UOW;
using Entity.Entities;
using Newtonsoft.Json;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.Caching.Redis
{
    public class RedisCache : ICacheManager
    {
        readonly IRedisCacheClient _redisCacheClient;
        public RedisCache(IRedisCacheClient redisCacheClient)
        {
            _redisCacheClient = redisCacheClient;
        }
        public void Add(string key, object data, int duration)
        {
            var json = _redisCacheClient.Db0.AddAsync(key, data, DateTime.Now.AddMinutes(30));
            _redisCacheClient.Serializer.Serialize(json).ToString();
            //_redisCacheClient.Db0.AddAsync(key, data, DateTime.Now.AddMinutes(30));
        }

        //public void Add<T>(string key, T data, int duration)
        //{
        //    _redisCacheClient.Db0.AddAsync<T>(key, data, DateTime.Now.AddMinutes(30));
        //}

        public T Get<T>(string key)
        {

            var json = _redisCacheClient.Db0.Database.StringGet(key);
            var end = JsonConvert.DeserializeObject<T>(json);
            var result = new SuccessDataResult<T>(end).Data;
            //var result = JsonConvert.DeserializeObject<T>(json.ToString());
            return result;
        }

        public object Get(string key)
        {
            var json = _redisCacheClient.Db0.Database.StringGet(key);

            //var result = JsonConvert.DeserializeObject<string>(json);

            //var aa = Convert.ToString(json);
            var result = JsonConvert.DeserializeObject<dynamic>(json);
            return new SuccessDataResult<List<dynamic>>(result);
        }

        public bool IsAdd(string key)
        {
            //throw new NotImplementedException();
            //return _redisCacheClient.Db0.GetByTagAsync<string>(key, out _);
            var result = _redisCacheClient.Db0.ExistsAsync(key);
            if (result.Result)
            {
                return true;
            }
            return false;
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
