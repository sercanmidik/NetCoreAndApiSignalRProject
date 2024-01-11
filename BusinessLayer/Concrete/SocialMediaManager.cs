using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void BusinnesAdd(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
        }

        public void BusinnesDelete(SocialMedia entity)
        {
           _socialMediaDal.Delete(entity);  
        }

        public SocialMedia BusinnesGetById(int id)
        {
          return  _socialMediaDal.GetById(id);
        }

        public List<SocialMedia> BusinnesGetListAll()
        {
            return _socialMediaDal.GetListAll();
        }

        public void BusinnesUpdate(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}
