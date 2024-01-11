using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.SocialMediaDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper  _mapper;

        public SocialMediaController(ISocialMediaService service, IMapper mapper)
        {
            _socialMediaService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaGetAll()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.BusinnesGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult SocialMediaAdd(CreateSocialMediaDto socialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(socialMediaDto);
            _socialMediaService.BusinnesAdd(value); 
            return Ok("Sosyal Media Başarılı şekilde Eklendi");
        }
        [HttpPut]
        public IActionResult SocialMediaUpdate(UpdateSocialMediaDto socialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(socialMediaDto);
            _socialMediaService.BusinnesUpdate(value);
            return Ok("Sosyal Media Başarılı şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult SocialMediaDelete(int id)
        {
            var value=_socialMediaService.BusinnesGetById(id);
            _socialMediaService.BusinnesDelete(value);
            return Ok("Sosyal Media Başarılı şekilde Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult SocialMediaGetById(int id)
        {
            var value = _socialMediaService.BusinnesGetById(id);
            return Ok(value);
        }
    }
}
