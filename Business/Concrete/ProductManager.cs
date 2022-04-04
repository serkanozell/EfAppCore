using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Messages;
using Business.Validations.FluentValidation;
using Core.AOP.Autofac.Caching;
using Core.AOP.Autofac.Logging;
using Core.AOP.Autofac.Transaction;
using Core.AOP.Autofac.Validation;
using Core.CrossCuttingConcern.Caching;
using Core.CrossCuttingConcern.Caching.Redis;
using Core.CrossCuttingConcern.Logging.Log4Net.Loggers;
using Core.Results;
using DataAccess.Concrete;
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
    public class ProductManager : IProductService
    {
        IUnitOfWork _unitOfWork;
        ICacheManager _cacheManager;
        IRedisCacheClient _redisCacheClient;
        private readonly static string key = "GetAllProducts";

        public ProductManager(IUnitOfWork unitOfWork/*, ICacheManager cacheManager, IRedisCacheClient redisCacheClient*/)
        {
            _unitOfWork = unitOfWork;
            //_cacheManager = cacheManager;
            //_redisCacheClient = redisCacheClient;
        }

        //[SecuredOperation("product.add,admin")]
        [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.SaveChanges();
            _redisCacheClient.Db0.Database.StringGetDelete(key);
            return new SuccessResult(Message.Added);
        }

        public IResult DeleteProduct(Product product)
        {
            _unitOfWork.Products.SoftDelete(product);
            _unitOfWork.SaveChanges();
            _redisCacheClient.Db0.Database.StringGetDelete(key);
            return new SuccessResult(Message.Deleted);
        }

        //[CacheAspect]
        public IDataResult<List<Product>> GetAllProducts()
        {
            //if (_cacheManager.IsAdd(key))
            //{
            //    var json = _redisCacheClient.Db0.Database.StringGet(key);
            //    var end = JsonConvert.DeserializeObject<List<Product>>(json);
            //    var sonuc = new SuccessDataResult<List<Product>>(end);
            //    return sonuc;
            //}

            //var result = new List<Product>(_unitOfWork.Products.GetAll());
            //var jsonData = _redisCacheClient.Db0.AddAsync
            //    (key, _unitOfWork.Products.GetAll(), DateTime.Now.AddMinutes(30));
            //_redisCacheClient.Serializer.Serialize(jsonData).ToString();
            var result = new SuccessDataResult<List<Product>>(_unitOfWork.Products.GetAll());
            return result;
        }

        [LogAspect(typeof(FileLogger))]
        public IDataResult<Product> GetProductByProductId(int id)
        {
            //var result = (_unitOfWork.Products.Get(p => p.ProductId == id));
            return new SuccessDataResult<Product>(_unitOfWork.Products.Get(p => p.ProductId == id));
        }
        [CacheAspect]
        [TransactionScopeAspect]
        public IDataResult<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            //var result = new List<Product>(_unitOfWork.Products.GetAll(p => p.CategoryId == categoryId));
            return new SuccessDataResult<List<Product>>(_unitOfWork.Products.GetAll(p => p.CategoryId == categoryId));
        }

        public IResult UpdateProduct(Product product)
        {
            _unitOfWork.Products.Update(product);
            _unitOfWork.SaveChanges();
            _redisCacheClient.Db0.Database.StringGetDelete(key);
            return new SuccessResult(Message.Updated);
        }

        #region AutoMapper Öncesi
        //public void AddProductVmToProduct(Product product)
        //{
        //    _unitOfWork.Products.Add(product);
        //    _unitOfWork.SaveChanges();
        //}

        //public void DeleteProductVmToProduct(ProductDeleteVM productVm)
        //{
        //    _unitOfWork.Products.DeleteProductVmToProduct(productVm);
        //    _unitOfWork.SaveChanges();
        //}

        //public List<ProductVM> GetAllProducts(/*List<Product> productList*/)
        //{
        //    var result = new List<ProductVM>(_unitOfWork.Products.GetAllProducts(/*productList*/));
        //    return result;
        //}

        //public Product GetProductByProductId(int id)
        //{
        //    var result = (_unitOfWork.Products.Get(p => p.ProductId == id));
        //    return result;
        //}

        //public List<ProductVM> GetProductsByCategoryId(int id)
        //{
        //    var result = new List<ProductVM>(_unitOfWork.Products.GetProductsByCategoryId(id));
        //    return result;
        //}

        //public void UpdateProductVmToProduct(ProductUpdateVM productVm)
        //{
        //    _unitOfWork.Products.UpdateProductVmToProduct(productVm);
        //    _unitOfWork.SaveChanges();
        //}
        #endregion
        //public Product GetByProductId(int productId)
        //{
        //    return  Product(_unitOfWork.Products.GetByProductId(p => p.ProductId == productId));
        //}
    }
}
