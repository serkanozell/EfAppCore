using DataAccess.Add;
using DataAccess.Delete;
using DataAccess.Select;
using DataAccess.Update;
using Entity.Entities;
using Entity.ViewModel;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICategoryRepository : IAddableRepository<Category>, IUpdatableRepository<Category>,
        IDeletableRepository<Category>, ISelectableRepository<Category>
    {

    }
}

#region AutoMapper öncesi
////Category AddCategoryVmToCategory(CategoryAddVM categoryAddVM);
//Category DeleteCategoryVmToCategory(CategoryDeleteVM categoryDeleteVM);
//Category UpdateCategoryVmToCategory(CategoryUpdateVM categoryUpdateVM);
//Category GetCategoriesByCategoryId(int id);
//List<CategoryVM> GetAllCategories();
#endregion
