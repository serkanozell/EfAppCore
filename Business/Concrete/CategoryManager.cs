using Business.Abstract;
using Business.Messages;
using Core.CrossCuttingConcern.Caching;
using Core.Results;
using DataAccess.UOW;
using Entity.Entities;
using Entity.ViewModel;
using Newtonsoft.Json;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        IUnitOfWork _unitOfWork;
        ICacheManager _cacheManager;
        IRedisCacheClient _redisCacheClient;
        private readonly static string key = "GetAllCategories";

        public CategoryManager(IUnitOfWork unitOfWork, ICacheManager cacheManager, IRedisCacheClient redisCacheClient)
        {
            _unitOfWork = unitOfWork;
            _cacheManager = cacheManager;
            _redisCacheClient = redisCacheClient;
        }
        public IResult AddCategory(Category category)
        {
            _unitOfWork.Categories.Add(category);
            _unitOfWork.SaveChanges();
            _redisCacheClient.Db0.Database.StringGetDelete(key);
            return new SuccessResult(Message.Added);
        }

        public IResult DeleteCategory(Category category)
        {
            _unitOfWork.Categories.SoftDelete(category);
            _unitOfWork.SaveChanges();
            _redisCacheClient.Db0.Database.StringGetDelete(key);
            return new SuccessResult(Message.Deleted);
        }

        public List<Category> GetAllCategories()
        {
            if (_cacheManager.IsAdd(key))
            {
                var json = _redisCacheClient.Db0.Database.StringGet(key);
                var end = JsonConvert.DeserializeObject<List<Category>>(json);
                return end;
            }
            var jsonData = _redisCacheClient.Db0.AddAsync
                (key, _unitOfWork.Categories.GetAll(), DateTime.Now.AddMinutes(30));
            _redisCacheClient.Serializer.Serialize(jsonData).ToString();
            var result = _unitOfWork.Categories.GetAll();
            return result;
        }

        public IDataResult<Category> GetCategoryByCategoryId(int id)
        {
            var result = _unitOfWork.Categories.Get(c => c.CategoryId == id);
            return new SuccessDataResult<Category>(_unitOfWork.Categories.Get(c => c.CategoryId == id));
        }

        public IResult UpdateCategory(Category category)
        {
            _unitOfWork.Categories.Update(category);
            _unitOfWork.SaveChanges();
            _redisCacheClient.Db0.Database.StringGetDelete(key);
            return new SuccessResult(Message.Updated);
        }
    }
}
