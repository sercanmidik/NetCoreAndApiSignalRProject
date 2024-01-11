using BusinessLayer.Abstract;
using DtoLayer.BookingDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
           var values= _bookingService.BusinnesGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult BookingAdd(CreateBookingDto bookingDto)
        {
            Booking booking = new Booking()
            {
                Date = bookingDto.Date,
                Mail = bookingDto.Mail,
                Name = bookingDto.Name,
                PersonCount = bookingDto.PersonCount,
                Phone = bookingDto.Phone,
                Description= "Rezervasyon Alındı",
            };
            _bookingService.BusinnesAdd(booking);
            return Ok("Rezervasyon İşlemi Kısmı Başarılı bir şekide eklendi");

        }
        [HttpPut]
        public IActionResult BookingUpdate(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                BookingId = updateBookingDto.BookingId,
				Description = updateBookingDto.Description,
			};
            _bookingService.BusinnesUpdate(booking);
            return Ok("Rezervasyon Güncellendi");

        }

        [HttpDelete("{id}")]
        public IActionResult BookingDelete(int id)
        {
            var value=_bookingService.BusinnesGetById(id);
            _bookingService.BusinnesDelete(value);
            return Ok("Rezervasyon Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult BookingGetById(int id)
        {
            var value = _bookingService.BusinnesGetById(id);
            return Ok(value);
        }

        [HttpGet("BookingCancel/{id}")]
        public IActionResult BookingCancel(int id)
        {
            _bookingService.BusinessBookingCanceled(id);
            return Ok("Rezervasyon İptal Edildi");
        }
		[HttpGet("BookingAccept/{id}")]
		public IActionResult BookingAccept(int id)
		{
			_bookingService.BusinessBookingStatusAccepted(id);
			return Ok("Rezervasyon Onaylandı");
		}
	}
}
