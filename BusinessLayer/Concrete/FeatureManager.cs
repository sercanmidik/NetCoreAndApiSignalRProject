using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void BusinnesAdd(Feature entity)
        {
           _featureDal.Add(entity); 
        }

        public void BusinnesDelete(Feature entity)
        {
           _featureDal.Delete(entity);
        }

        public Feature BusinnesGetById(int id)
        {
           return _featureDal.GetById(id);
        }

        public List<Feature> BusinnesGetListAll()
        {
            return _featureDal.GetListAll();
        }

        public void BusinnesUpdate(Feature entity)
        {
           _featureDal.Update(entity);  
        }
    }
}
