using DataAccess.Abstract;
using DataAccess.Repository.Repository;
using Entity.Entities;
using Entity.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccess.Concrete
{
    public class EfProductRepository : Repository<Product>, IProductRepository
    {
        public EfProductRepository(DbContext context) : base(context)
        {

        }
    }
}

#region AutoMapper Öncesi
//        public Product AddProductVmToProduct(ProductAddVM productVm)
//        {
//            var result = new Product()
//            {
//                CategoryId = productVm.CategoryId,
//                ProductName = productVm.ProductName,
//                UnitPrice = productVm.UnitPrice,
//                UnitsInStock = productVm.UnitsInStock,
//                IsActive = productVm.IsActive
//            };
//            _table.Add(result);
//            return result;
//        }


//        public Product DeleteProductVmToProduct(ProductDeleteVM productVm)
//        {
//            var result = new Product()
//            {
//                ProductId = productVm.ProductId,
//                CategoryId = productVm.CategoryId,
//                IsActive = false
//            };
//            _table.Update(result);
//            return result;
//        }

//        public List<ProductVM> GetAllProducts(/*List<Product> productList*/)
//        {
//            return new ProductVmListConverter().GetProductList(this.GetAll());
//            //List<ProductVM> productVmList = new List<ProductVM>();
//            ////foreach (Product product in productList)
//            ////{
//            ////    productVmList.Add(ProductToProductVm(product));
//            ////}
//            //return productVmList;
//        }

//        public Product GetProductByProductId(int id)
//        {
//            //return new ProductVmListConverter().GetProductByProductId(this.Get(p=>p.ProductId==id));
//            var result = new Product()
//            {
//                ProductId = id,
//            };
//            _table.Find(id);
//            return result;
//        }

//        public List<ProductVM> GetProductsByCategoryId(int id)
//        {
//            return new ProductVmListConverter().GetProductList(this.GetAll(p => p.CategoryId == id));
//        }

//        public Product UpdateProductVmToProduct(ProductUpdateVM productVm)
//        {
//            var result = new Product()
//            {
//                ProductId = productVm.ProductId,
//                CategoryId = productVm.CategoryId,
//                ProductName = productVm.ProductName,
//                UnitPrice = productVm.UnitPrice,
//                UnitsInStock = productVm.UnitsInStock,
//                IsActive = productVm.IsActive,
//            };
//            _table.Update(result);
//            return result;
//        }

//    }
//    internal class ProductVmListConverter
//    {
//        protected internal List<ProductVM> GetProductList(List<Product> productList)
//        {
//            List<ProductVM> productVmList = new List<ProductVM>();
//            foreach (Product product in productList)
//            {
//                productVmList.Add(ProductToProductVm(product));
//            }
//            return productVmList;
//        }
//        protected internal Product GetProductByProductId(int id)
//        {
//            Product product = new Product();
//            var result = new Product()
//            {
//                ProductId = id,
//            };
//            product = result;
//            return product;
//        }
//        protected private ProductVM ProductToProductVm(Product product)
//        {
//            return new ProductVM()
//            {
//                ProductId = product.ProductId,
//                CategoryId = product.CategoryId,
//                ProductName = product.ProductName,
//                UnitPrice = product.UnitPrice,
//                UnitsInStock = product.UnitsInStock,
//                IsActive = product.IsActive
//            };
//        }
//    }
//}
#endregion

#region EskiDenemeler
//public List<Product> GetProducts()
//{
//    using (EfAppContext context = new EfAppContext())
//    {
//        var result = from p in context.Product
//                     select new Product
//                     {
//                         ProductId = p.ProductId,
//                         ProductName = p.ProductName,
//                         //  Category = (Category)c.CategoryName,
//                         UnitPrice = p.UnitPrice,
//                         UnitsInStock = p.UnitsInStock,
//                         IsActive = p.IsActive
//                     };
//        return result.ToList();
//    }
//}
//public Product ProductAddVmToProduct(ProductAddVM vm)
//{
//    var deneme = new Product()
//    {
//        CategoryId = vm.CategoryId,
//        ProductName = vm.ProductName,
//        UnitPrice = vm.UnitPrice,
//        UnitsInStock = vm.UnitsInStock,
//        IsActive = vm.IsActive,

//    };
//    Repository<Product, EfAppContext> repo = new Repository<Product, EfAppContext>();
//    repo.Add(deneme);
//    return null;
//}
#endregion