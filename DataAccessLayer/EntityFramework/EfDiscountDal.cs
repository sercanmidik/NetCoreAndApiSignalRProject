using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;

namespace DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
		private readonly SignalRContext _context;
        public EfDiscountDal(SignalRContext context) : base(context)
        {
			_context = context;
        }

		public void ChangeStatus(int id)
		{
			var value = _context.Discounts.Find(id);
			if (value != null)
			{
				if (value.Status == true)
				{
					value.Status = false;
					
				}
				else
				{
				    value.Status=true;
					

				}
				_context.SaveChanges();
			}
		}

		public List<Discount> GetDiscountTrueTopThree()
		{
			return _context.Discounts.Where(x=>x.Status==true).Take(3).ToList();
		}
	}
   

}
