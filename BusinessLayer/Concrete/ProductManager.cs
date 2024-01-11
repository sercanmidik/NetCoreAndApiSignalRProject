using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> BusinessGetProductWithCategories()
        {
            return _productDal.GetProductWithCategories();
        }

        public decimal BusinessMaxProductPrice()
        {
            return _productDal.ProductMaxPrice();
        }

        public decimal BusinessMinProductPrice()
        {
            return _productDal.ProductMinPrice();
        }

        public decimal BusinessProductAvgPrice()
        {
            return _productDal.ProductAvgPrice();
        }

        public int BusinessProductCount()
        {
            return _productDal.ProductCount();
        }

        public void BusinnesAdd(Product entity)
        {
           _productDal.Add(entity); 
        }

        public void BusinnesDelete(Product entity)
        {
          _productDal.Delete(entity);   
        }

        public Product BusinnesGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> BusinnesGetListAll()
        {
           return _productDal.GetListAll(); 
        }

        public decimal BusinnessGetCategoryAvgPrice(int categoryId)
        {
           return _productDal.ByCategoryProductAvgPrice(categoryId);
        }

        public int BusinnessProductCountByCategoryName(int categoryId)
        {
            return _productDal.ProductCountByCategoryName(categoryId);
        }

        public void BusinnesUpdate(Product entity)
        {
           _productDal.Update(entity);
        }

        public string MaxPriceProductName()
        {
           return _productDal.MaxPriceProductName();
        }

        public string MinPriceProductName()
        {
            return _productDal.MinPriceProductName();
        }
    }
}
