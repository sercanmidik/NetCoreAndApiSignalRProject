using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ContactDto;
using DtoLayer.DiscountDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountGetAll()
        {
            var values=_mapper.Map<List<ResultDiscountDto>>(_discountService.BusinnesGetListAll());
            return Ok(values);

        }
		[HttpGet("DiscountGetTrueTopThree")]
		public IActionResult DiscountGetTrueTopThree()
		{
			var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.BusinessGetDiscountTrueTopThree());
			return Ok(values);

		}
		[HttpPost]
        public IActionResult DiscountCreate(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            _discountService.BusinnesAdd(value);
            return Ok("İndirimli ürün Başarılı şekilde Eklendi");
        }

        [HttpPut]
        public IActionResult DiscountUpdate(UpdateDiscountDto updateDiscountDto)
        {
            var value=_mapper.Map<Discount>(updateDiscountDto);
            _discountService.BusinnesUpdate(value);
            return Ok("İndirimli ürün Başarılı şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DiscountDelete(int id)
        {
            var value=_discountService.BusinnesGetById(id);
            _discountService.BusinnesDelete(value);
            return Ok("İndirimli ürün Başarılı şekilde silindi");
        }

        [HttpGet("{id}")]
        public IActionResult DiscountGetById(int id)
        {
            var value = _discountService.BusinnesGetById(id);
            return Ok(value);
        }
        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _discountService.BusinessChangeStatus(id);
            return Ok("Durumu Değişti");
        }
    }
}
