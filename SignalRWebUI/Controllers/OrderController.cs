using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MenuTableDtos;
using SignalRWebUI.Dtos.OrderDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class OrderController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public OrderController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7215/api/Order/TodayOrderList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultOrderDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task <IActionResult> OrderCreate()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7215/api/MenuTable/MenuTablePassiveList");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
			List<SelectListItem> values2 = (from x in values
											select new SelectListItem
											{
												Text = x.Name,
												Value = x.Name
											}).ToList();
			ViewBag.menutable = values2;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> OrderCreate(CreateOrderDto orderDto)
		{
			orderDto.TotalPrice = 0;
			orderDto.OrderDate = DateTime.Now;
			orderDto.Description = "Müşteri Masada";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(orderDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7215/api/Order", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				await client.GetAsync($"https://localhost:7215/api/MenuTable/MenuTableChange/{orderDto.TableNumber}");
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> OrderDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7215/api/Order/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> OrderUpdate(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7215/api/Order/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateOrderDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> OrderUpdate(UpdateOrderDto orderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(orderDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7215/api/Order/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}
		[HttpGet]
		public async Task<IActionResult> OrderClosed(int orderId)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7215/api/Order/OrderGetById/{orderId}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetByOrderDto>(jsonData);
				var client1 = _httpClientFactory.CreateClient();
				var responseMessage1 = await client1.GetAsync($"https://localhost:7215/api/Order/OrderIdDesciptionChange/{values?.OrderId}");
				if (responseMessage.IsSuccessStatusCode)
				{
					await client.GetAsync($"https://localhost:7215/api/MenuTable/MenuTableChange/{values?.TableNumber}");
					return RedirectToAction("Index");
				}
			}
			
			return View();
		}
	}
}
