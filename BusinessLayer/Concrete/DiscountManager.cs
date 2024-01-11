using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

		public void BusinessChangeStatus(int id)
		{
			_discountDal.ChangeStatus(id);
		}

		public List<Discount> BusinessGetDiscountTrueTopThree()
		{
		   return _discountDal.GetDiscountTrueTopThree();
		}

		public void BusinnesAdd(Discount entity)
        {
           _discountDal.Add(entity);
        }

        public void BusinnesDelete(Discount entity)
        {
           _discountDal.Delete(entity);
        }

        public Discount BusinnesGetById(int id)
        {
           return _discountDal.GetById(id);
        }

        public List<Discount> BusinnesGetListAll()
        {
            return _discountDal.GetListAll();
        }

        public void BusinnesUpdate(Discount entity)
        {
           _discountDal.Update(entity);
        }
    }
}
