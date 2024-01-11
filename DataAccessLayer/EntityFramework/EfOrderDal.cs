using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;

namespace DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly SignalRContext _context;
        public EfOrderDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int ActiveOrderCount()
        {
           return _context.Orders.Where(x=>x.Description=="Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
           return _context.Orders.OrderByDescending(x=>x.OrderId).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

		public void OrderIdByOrderClosed(int orderId)
		{
            var value=_context.Orders.Where(x => x.OrderId == orderId).FirstOrDefault();
            if(value != null)
            {
                value.Description = "Hesap Kapatıldı";
                _context.SaveChanges();
			}
           
		}

		public List<Order> TodayOrders()
		{
			return _context.Orders.Where(x=>x.OrderDate.Year==DateTime.Now.Year && x.OrderDate.Month==DateTime.Now.Month && x.OrderDate.Day==DateTime.Now.Day && x.Description== "Müşteri Masada").ToList();
		}

		public decimal TodayTotalPrice()
        {
            return _context.Orders.Where(x=>x.OrderDate==DateTime.Now.Date).Sum(y=>y.TotalPrice);
        }

        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }

    }
}
