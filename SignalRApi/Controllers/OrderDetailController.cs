using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.OrderDetailDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult OrderDetailList()
        {
            var values=_mapper.Map<List<ResultOrderDetailDto>>(_orderDetailService.BusinnesGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult OrderDetailAdd(CreateOrderDetailDto orderDetailDto)
        {
            var value = _mapper.Map<OrderDetail>(orderDetailDto);
            _orderDetailService.BusinnesAdd(value);
            return Ok("Sipariş Detayı başarılı şekilde eklendi");
        }
        [HttpPut]
        public IActionResult OrderDetailUpdate(UpdateOrderDetailDto orderDetailDto)
        {
            var value =_mapper.Map<OrderDetail>(orderDetailDto);
            _orderDetailService.BusinnesUpdate(value);
            return Ok("Sipariş Detayı Başarlı Şekilde Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult OrderDetailDelete(int id)
        {
            var value=_orderDetailService.BusinnesGetById(id);
            _orderDetailService.BusinnesDelete(value);
            return Ok("Sipariş Detayı Başarılı Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult OrderDetailGetById(int id)
        {
            var value = _orderDetailService.BusinnesGetById(id);
            return Ok(value);
        }

		[HttpGet("OrderDetailGetByOrderId/{id}")]
		public IActionResult OrderDetailGetByOrderId(int id)
		{
			var value = _orderDetailService.BusinnesGetByIdOrderList(id);
			return Ok(value);
		}
        [HttpGet("GetOrderDetailWithProduct/{id}")]
        public IActionResult GetOrderDetailWithProduct(int id)
        {
			using var context = new SignalRContext();
			var values = context.OrderDetails.Include(x => x.Product).Where(y => y.OrderId == id).Select(z => new ResultOrderDetailWithProduct
			{
				ProductName=z.Product.ProductName,
                Count=z.Count,
                OrderId=z.OrderId,
                OrderDetailId = z.OrderDetailId,
                ProductId=z.ProductId,
                TotalPrice = z.TotalPrice,
                UnitPrice = z.UnitPrice
                
			}).ToList();
			return Ok(values);
		}
        [HttpPost("CreateOrUpdate")]
        public IActionResult CreateOrUpdate(CreateOrderDetailDto dto)
        {
            CountPlusDetailDto countPlusDetailDto = new CountPlusDetailDto()
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
            };
            var result = _orderDetailService.BusinessOrderIdInProductId(countPlusDetailDto);
            if(result==true)
            {
                _orderDetailService.BusinessCountPlus(countPlusDetailDto);
                return Ok("Ürün Güncellendi");
            }
            else
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    Count = dto.Count,
                    ProductId = dto.ProductId,
                    OrderId = dto.OrderId,
                    TotalPrice=dto.TotalPrice,
                    UnitPrice=dto.UnitPrice

                };
                _orderDetailService.BusinnesAdd(orderDetail);
                return Ok("Ürün Eklendi");
            }
        }
	}
}
