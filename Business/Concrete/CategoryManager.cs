using Business.Abstract;
using Business.Messages;
using Core.Results;
using DataAccess.UOW;
using Entity.Entities;
using Entity.ViewModel;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IResult AddCategory(Category category)
        {
            _unitOfWork.Categories.Add(category);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Message.Added);
        }

        public IResult DeleteCategory(Category category)
        {
            _unitOfWork.Categories.SoftDelete(category);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<Category>> GetAllCategories()
        {
            //var result = _unitOfWork.Categories.GetAllCategories();
            return new SuccessDataResult<List<Category>>(_unitOfWork.Categories.GetAll());
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
            return new SuccessResult(Message.Updated);
        }
    }
}
