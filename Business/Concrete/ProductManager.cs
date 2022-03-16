using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Messages;
using Business.Validations.FluentValidation;
using Core.AOP.Autofac.Caching;
using Core.AOP.Autofac.Logging;
using Core.AOP.Autofac.Transaction;
using Core.AOP.Autofac.Validation;
using Core.CrossCuttingConcern.Logging.Log4Net.Loggers;
using Core.Results;
using DataAccess.Concrete;
using DataAccess.UOW;
using Entity.Entities;
using Entity.ViewModel;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //[SecuredOperation("product.add,admin")]
        [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Message.Added);
        }

        public IResult DeleteProduct(Product product)
        {
            _unitOfWork.Products.SoftDelete(product);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Message.Deleted);
        }

        [CacheAspect]

        public IDataResult<List<Product>> GetAllProducts()
        {
            //var result = new List<Product>(_unitOfWork.Products.GetAll());
            return new SuccessDataResult<List<Product>>(_unitOfWork.Products.GetAll(), Message.ProductsListed);
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
