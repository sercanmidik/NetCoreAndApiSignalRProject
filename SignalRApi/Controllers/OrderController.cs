using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.OrderDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;


        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var values=_mapper.Map<List<ResultOrderDto>>(_orderService.BusinnesGetListAll());
            return Ok(values);  
        }
		[HttpGet("TodayOrderList")]
		public IActionResult TodayOrderList()
		{
			var values = _mapper.Map<List<ResultOrderDto>>(_orderService.BusinnessTodayOrders());
			return Ok(values);
		}

		[HttpPost]
        public IActionResult OrderAdd(CreateOrderDto orderDto)
        {
            var value = _mapper.Map<Order>(orderDto);
			value.OrderDate = DateTime.Now;
            value.TotalPrice = 0;
            value.Description = "Müşteri Masada";
			_orderService.BusinnesAdd(value);
            return Ok("Başarılı Şekilde sipariş oluşturuldu");
        }

        [HttpPut]
        public IActionResult OrderUpdate(UpdateOrderDto orderDto)
        {
            var value= _mapper.Map<Order>(orderDto);
            _orderService.BusinnesUpdate(value);
            return Ok("Siparis Başarılı Şekilde Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult OrderDelete(int id)
        {
           var value=_orderService.BusinnesGetById(id);
            _orderService.BusinnesDelete(value);
            return Ok("sipariş başarılı şekilde silindi");
        }

        [HttpGet("OrderGetById/{id}")]
        public IActionResult OrderGetById(int id)
        {
            var value = _orderService.BusinnesGetById(id);
            return Ok(value);
        }

        [HttpGet("OrderAllCount")]
        public IActionResult OrderAllCount()
        {
            return Ok(_orderService.BusinessTotalOrderCount());
        }
        [HttpGet("OrderActiveCount")]
        public IActionResult OrderActiveCount()
        {
            return Ok(_orderService.BusinessActiveOrderCount());
        }

        [HttpGet("OrderLastPrice")]
        public IActionResult OrderLastPrice()
        {
            return Ok(_orderService.BusinessLastOrderPrice());
        }
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            return Ok(_orderService.BusinessTodayTotalPrice());
        }

		[HttpGet("OrderIdDesciptionChange/{orderId}")]
		public IActionResult OrderIdDesciptionChange(int orderId)
		{
            _orderService.BusinessOrderIdByOrderClosed(orderId);
			return Ok("Başarılı ile değişti");
		}

	}
}
