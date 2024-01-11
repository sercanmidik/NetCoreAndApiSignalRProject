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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

		public void BusinessBookingCanceled(int id)
		{
			_bookingDal.BookingCanceled(id);
		}

		public void BusinessBookingStatusAccepted(int id)
		{
			_bookingDal.BookingStatusAccepted(id);
		}

		public void BusinnesAdd(Booking entity)
        {
           _bookingDal.Add(entity);
        }

        public void BusinnesDelete(Booking entity)
        {
         _bookingDal.Delete(entity);
        }

        public Booking BusinnesGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public List<Booking> BusinnesGetListAll()
        {
           return _bookingDal.GetListAll();
        }

        public void BusinnesUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
