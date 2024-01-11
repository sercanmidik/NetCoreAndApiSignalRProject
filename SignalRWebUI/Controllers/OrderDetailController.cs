using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRApi.Models;
using SignalRWebUI.Dtos.OrderDetailDtos;
using SignalRWebUI.Dtos.OrderDtos;
using SignalRWebUI.Dtos.ProductsDtos;
using SignalRWebUI.Models;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class OrderDetailController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public OrderDetailController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
			
		}
		[HttpGet]
		public async Task<IActionResult> OrderDetailList(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7215/api/OrderDetail/GetOrderDetailWithProduct/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				ViewBag.tableNumber = id;
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultOrderDetailWithProduct>>(jsonData);
				return View(values);
			}
			return View();
		}	

        public async Task<IActionResult> OrderDetailDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7215/api/OrderDetail/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index","Order");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> OrderDetailCreate(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7215/api/Product");
			if (responseMessage != null)
			{
				ViewBag.orderId = id;
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();

		}
		[HttpPost]
		public async Task<IActionResult> OrderDetailCreate(CreateDetailProductIdWithOrderId createOrderDto)
		{
			CreateOrderDetailDto createOrderDetailDto = new CreateOrderDetailDto()
			{
				Count = 1,
				OrderId = createOrderDto.OrderId,
				ProductId = createOrderDto.ProductId,
				UnitPrice = createOrderDto.UnitPrice,
				TotalPrice = createOrderDto.UnitPrice*1

			};
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOrderDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7215/api/OrderDetail/CreateOrUpdate", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Order");
            }
            return View();
           
		}
	}
}
