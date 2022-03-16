using DataAccess.Add;
using DataAccess.Delete;
using DataAccess.Select;
using DataAccess.Update;
using Entity.Entities;
using Entity.ViewModel;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IProductRepository : IAddableRepository<Product>, IUpdatableRepository<Product>,
        IDeletableRepository<Product>, ISelectableRepository<Product>
    {

        #region AutoMapper Öncesi
        //Product AddProductVmToProduct(ProductAddVM productVm);
        //Product UpdateProductVmToProduct(ProductUpdateVM productVm);
        //Product DeleteProductVmToProduct(ProductDeleteVM productVm);
        //Product GetProductByProductId(int id);
        //List<ProductVM> GetAllProducts(/*List<Product> productList*/);
        //List<ProductVM> GetProductsByCategoryId(int id);
        #endregion
    }
}
