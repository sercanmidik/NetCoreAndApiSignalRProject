using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;


namespace SignalRWebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(CreateMailDto mailDto)
		{
			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAdress = new MailboxAddress("Rezervasyon", "sercanmidik@gmail.com");
			mimeMessage.From.Add(mailboxAdress);
			MailboxAddress mailBoxAdressTo= new MailboxAddress("User", mailDto.ReceiverMail);
			mimeMessage.To.Add(mailBoxAdressTo);
			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody=mailDto.Body;
			mimeMessage.Body=bodyBuilder.ToMessageBody();
			mimeMessage.Subject=mailDto.Subject;
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com",587,false);
			client.Authenticate("sercanmidik@gmail.com", "zweq tkuc xtvv alcw");
			client.Send(mimeMessage);
			client.Disconnect(true);
		
			return RedirectToAction("Index", "Statistic");
		}
	}
}
