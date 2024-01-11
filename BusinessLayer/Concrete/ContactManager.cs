using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void BusinnesAdd(Contact entity)
        {
           _contactDal.Add(entity);
        }

        public void BusinnesDelete(Contact entity)
        {
           _contactDal.Delete(entity);
        }

        public Contact BusinnesGetById(int id)
        {
           return _contactDal.GetById(id);
        }

        public List<Contact> BusinnesGetListAll()
        {
            return _contactDal.GetListAll();
        }

        public void BusinnesUpdate(Contact entity)
        {
            _contactDal.Update(entity); 
        }
    }
}
