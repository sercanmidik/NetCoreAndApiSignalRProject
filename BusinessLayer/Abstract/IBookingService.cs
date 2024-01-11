using EntityLayer.Entites;

namespace BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
		void BusinessBookingStatusAccepted(int id);
		void BusinessBookingCanceled(int id);
	}

}
