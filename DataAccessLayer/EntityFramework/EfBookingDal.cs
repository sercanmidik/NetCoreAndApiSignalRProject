using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;

namespace DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
		private readonly SignalRContext _context;
        public EfBookingDal(SignalRContext context) : base(context)
        {
			_context = context;
        }

		public void BookingCanceled(int id)
		{
			var value=_context.Bookings.Where(x=>x.BookingId==id).FirstOrDefault();
			if(value != null)
			{
				value.Description = "Rezervasyon İptal Edildi";
				_context.SaveChanges();
			}
		}

		public void BookingStatusAccepted(int id)
		{
			var value = _context.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
			if(value != null)
			{
				value.Description = "Rezervasyon Onaylandı";
				_context.SaveChanges();
			}
			
		}
	}
   

}
