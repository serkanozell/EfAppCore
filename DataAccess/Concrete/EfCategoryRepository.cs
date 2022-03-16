using DataAccess.Abstract;
using DataAccess.Repository.Repository;
using Entity.Entities;
using Entity.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccess.Concrete
{
    public class EfCategoryRepository : Repository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {

        }
    }
}
#region AutoMapper Öncesi
//    //public Category AddCategoryVmToCategory(CategoryAddVM categoryAddVM)
//    //{
//    //    var result = new Category()
//    //    {
//    //        CategoryName = categoryAddVM.CategoryName,
//    //        IsActive = categoryAddVM.IsActive
//    //    };
//    //    _table.Add(result);
//    //    return result;
//    //}

//    public Category DeleteCategoryVmToCategory(CategoryDeleteVM categoryDeleteVM)
//    {
//        var result = new Category()
//        {
//            CategoryId = categoryDeleteVM.CategoryId,
//            IsActive = false
//        };
//        _table.Remove(result);
//        return result;
//    }

//    public List<CategoryVM> GetAllCategories()
//    {
//        return new CategoryVmListConverter().GetCategoryList(this.GetAll());
//    }

//    public Category GetCategoriesByCategoryId(int id)
//    {
//        throw new System.NotImplementedException();
//    }

//    public Category UpdateCategoryVmToCategory(CategoryUpdateVM categoryUpdateVM)
//    {
//        var result = new Category()
//        {
//            CategoryId = categoryUpdateVM.CategoryId,
//            CategoryName = categoryUpdateVM.CategoryName,
//            IsActive = categoryUpdateVM.IsActive
//        };
//        _table.Update(result);
//        return result;
//    }
//}

//internal class CategoryVmListConverter
//{
//    protected internal List<CategoryVM> GetCategoryList(List<Category> categoryList)
//    {
//        List<CategoryVM> categoryVmList = new List<CategoryVM>();
//        foreach (var category in categoryList)
//        {
//            categoryVmList.Add(CategoryToCategoryVm(category));
//        }
//        return categoryVmList;
//    }
//    private CategoryVM CategoryToCategoryVm(Category category)
//    {
//        return new CategoryVM()
//        {
//            CategoryId = category.CategoryId,
//            CategoryName = category.CategoryName,
//            IsActive = category.IsActive
//        };
//    }
//}
#endregion