using BusinessLayer.Abstract;
using DtoLayer.AboutDto;
using DtoLayer.MessageDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessageController(IMessageService messageService)
		{
			_messageService = messageService;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.BusinnesGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult MessageAdd(CreateMessageDto messageDto)
		{
			Message message = new Message()
			{
				NameSurname = messageDto.NameSurname,
				Mail = messageDto.Mail,
				MessageContent = messageDto.MessageContent,
				MessageSendDate = DateTime.Now,
				Phone = messageDto.Phone,
				Status = false,
				Subject = messageDto.Subject,
			};
			_messageService.BusinnesAdd(message);
			return Ok("Mesaj Başarılı bir şekide eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult MessageDelete(int id)
		{
			var value = _messageService.BusinnesGetById(id);
			_messageService.BusinnesDelete(value);
			return Ok("Mesaj Silindi");
		}
		[HttpPut]
		public IActionResult MessageUpdate(UpdateMessageDto messageDto)
		{
			Message message = new Message()
			{
				MessageId = messageDto.MessageId,
				NameSurname = messageDto.NameSurname,
				Mail = messageDto.Mail,
				MessageContent = messageDto.MessageContent,
				MessageSendDate = DateTime.Now,
				Phone = messageDto.Phone,
				Status = false,
				Subject = messageDto.Subject,
			};
			_messageService.BusinnesUpdate(message);
			return Ok("Mesaj Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult MessageGetById(int id)
		{
			var value = _messageService.BusinnesGetById(id);
			return Ok(value);
		}
	}
}
