using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int BusinessCategoryCount()
        {
            return _categoryDal.CategoryCount();
        }

        public void BusinnesAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void BusinnesDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category BusinnesGetById(int id)
        {
           return _categoryDal.GetById(id);
        }

        public List<Category> BusinnesGetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public void BusinnesUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public int BusinessCategoryActiveCount()
        {
            return _categoryDal.CategoryActiveCount();
        }

        public int BusinessCategoryPassiveCount()
        {
            return _categoryDal.CategoryPassiveCount();
        }
    }
}
