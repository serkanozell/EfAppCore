using Core.Results;
using Entity.Entities;
using Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult AddProduct(Product product);
        IResult UpdateProduct(Product product);
        IResult DeleteProduct(Product product);
        IDataResult<Product> GetProductByProductId(int id);
        IDataResult<List<Product>> GetAllProducts();
        IDataResult<List<Product>> GetProductsByCategoryId(int categoryId);
    }

    #region AutoMapper Öncesi
    //void AddProductVmToProduct(Product product);
    //void UpdateProductVmToProduct(ProductUpdateVM productVm);
    //void DeleteProductVmToProduct(ProductDeleteVM productVm);
    //public Product GetProductByProductId(int id);
    //public List<ProductVM> GetAllProducts(/*List<Product> productList*/);
    //public List<ProductVM> GetProductsByCategoryId(int id);
    #endregion
}
