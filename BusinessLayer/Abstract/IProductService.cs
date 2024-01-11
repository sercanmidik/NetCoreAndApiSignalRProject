using EntityLayer.Entites;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> BusinessGetProductWithCategories();
        public int BusinessProductCount();
        int BusinnessProductCountByCategoryName(int categoryId);
        decimal BusinessProductAvgPrice();
        decimal BusinessMaxProductPrice();
        decimal BusinessMinProductPrice();
        decimal BusinnessGetCategoryAvgPrice(int categoryId);
        string MaxPriceProductName();
        string MinPriceProductName();
    }

}
