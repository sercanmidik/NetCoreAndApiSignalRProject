using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.TestimonialDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialGetAll()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.BusinnesGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult TestimonialAdd(CreateTestimonialDto testimonialDto)
        {
            var value = _mapper.Map<Testimonial>(testimonialDto);
            _testimonialService.BusinnesAdd(value);
            return Ok("Yorum başarılı şekilde eklendi");
        }
        [HttpPut]
        public IActionResult TestimonialUpdate(UpdateTestimonialDto testimonialDto)
        {
            var value = _mapper.Map<Testimonial>(testimonialDto);
            _testimonialService.BusinnesUpdate(value);
            return Ok("Yorum başarılı şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult TestimonialDelete(int id)
        {
            var value=_testimonialService.BusinnesGetById(id);
            _testimonialService.BusinnesDelete(value);
            return Ok("Yorum başarılı şekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult TestimonialGetById(int id)
        {
            var value = _testimonialService.BusinnesGetById(id);
            return Ok(value);
        }
    }
}
