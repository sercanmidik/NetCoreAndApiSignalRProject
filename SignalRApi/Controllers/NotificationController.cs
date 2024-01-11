using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.CategoryDto;
using DtoLayer.NotificationDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_notificationService.BusinnesGetListAll());
		}

		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.BusinessNotificationCountByStatusFalse());
		}
		[HttpGet("NotificationGetAllListByFalse")]
		public IActionResult NotificationGetAllListByFalse()
		{
			return Ok(_notificationService.BusinnessGetAllNotificationByFalse());
		}

		[HttpPost]
		public IActionResult NotificationCreate(CreateNotificationDto createNotificationDto)
		{
			var value = _mapper.Map<Notification>(createNotificationDto);
			createNotificationDto.Date= DateTime.Now;
			createNotificationDto.Status = false;
			_notificationService.BusinnesAdd(value);
			return Ok("Başarılı şekilde eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult NotificationDelete(int id)
		{
			var value=_notificationService.BusinnesGetById(id);	
			_notificationService.BusinnesDelete(value);
			return Ok("Bildirim Silindi");
		}
		[HttpGet("NotificationGetById/{id}")]
		public IActionResult NotificationGetById(int id)
		{
			var value = _notificationService.BusinnesGetById(id);
			return Ok(value);
		}
		[HttpPut("NotificationStatusChange/{id}")]
		public IActionResult NotificationStatusChange(int id)
		{
		   _notificationService.BusinessNotificationChange(id);
			return Ok("Değişti");
		}
		[HttpPut]
		public IActionResult NotificationUpdate(UpdateNotificationDto updateNotificationDto)
		{
			var value=_mapper.Map<Notification>(updateNotificationDto);
			updateNotificationDto.Date = DateTime.Now;
			updateNotificationDto.Status = false;
			_notificationService.BusinnesUpdate(value);
			return Ok("Güncelleme Başarılı");
		}
	}
}
