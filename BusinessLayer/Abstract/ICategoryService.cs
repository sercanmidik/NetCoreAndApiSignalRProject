using EntityLayer.Entites;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        public int BusinessCategoryCount();
        public int BusinessCategoryActiveCount();
        public int BusinessCategoryPassiveCount();
    }

}
