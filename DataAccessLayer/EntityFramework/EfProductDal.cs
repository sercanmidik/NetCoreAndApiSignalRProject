using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.ProductDto;
using EntityLayer.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly SignalRContext _context;
        public EfProductDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public decimal ByCategoryProductAvgPrice(int categoryId)
        {
            return _context.Products.Where(x => x.CategoryId == categoryId).Average(x => x.Price);
        }

        public List<Product> GetProductWithCategories()
        {
            
            var values=_context.Products.Include(x=>x.Category).ToList();
            return values;
        }

        public string MaxPriceProductName()
        {
            return _context.Products.OrderByDescending(x => x.Price).Select(x => x.ProductName).FirstOrDefault() ?? "EMİNİM BOŞ GELMEYECEK";
        }

        public string MinPriceProductName()
        {
            return _context.Products.OrderBy(x => x.Price).Select(x => x.ProductName).FirstOrDefault() ?? "EMİNİM BOŞ GELMEYECEK";
        }

        public decimal ProductAvgPrice()
        {
            return _context.Products.Average(x=>x.Price);
        }

        public int ProductCount()
        {
            return _context.Products.Count();
        }

        public int ProductCountByCategoryName(int categoryId)
        {
            return _context.Products.Where(x =>x.CategoryId==categoryId).Count();
        }

        public decimal ProductMaxPrice()
        {
           return _context.Products.Max(x=>x.Price);
        }

        public decimal ProductMinPrice()
        {
            return _context.Products.Min(x => x.Price);
        }
    }
   

}
