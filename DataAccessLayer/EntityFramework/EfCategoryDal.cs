using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly SignalRContext _context;
        public EfCategoryDal(SignalRContext context) : base(context)
        {
            _context = context;
        }
       
        public int CategoryActiveCount()
        {
            return _context.Categories.Where(x=>x.CategoryStatus==true).Count();
        }

        public int CategoryCount()
        {
            
            return _context.Categories.Count();
        }

        public int CategoryPassiveCount()
        {
            return _context.Categories.Where(x=>x.CategoryStatus==false).Count();
        }
    }
   

}
