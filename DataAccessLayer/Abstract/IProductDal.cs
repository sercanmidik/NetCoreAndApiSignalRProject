using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductWithCategories();
        int ProductCount();

        int ProductCountByCategoryName(int categoryId);
        decimal ByCategoryProductAvgPrice(int categoryId);

        decimal ProductAvgPrice();
        decimal ProductMaxPrice();
        decimal ProductMinPrice();

        string MaxPriceProductName();
        string MinPriceProductName();



    }
}
