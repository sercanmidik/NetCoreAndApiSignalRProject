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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void BusinnesAdd(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void BusinnesDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About BusinnesGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> BusinnesGetListAll()
        {
           return _aboutDal.GetListAll();
        }

        public void BusinnesUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
