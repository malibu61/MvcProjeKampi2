using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }


        public int TCategoryCount()
        {
            return _categoryDal.CategoryCount();

        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public string TCategoryWithMostTitle()
        {
            return _categoryDal.CategoryWithMostTitle();
        }

        public int DistinctionBetweenTrueAndFalseInCategory()
        {
            return _categoryDal.DistinctionBetweenTrueAndFalseInCategory();
        }

        public string LongestCategoryName()
        {
           return _categoryDal.LongestCategoryName();
        }
    }
}
