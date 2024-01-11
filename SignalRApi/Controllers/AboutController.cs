using BusinessLayer.Abstract;
using DtoLayer.AboutDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.BusinnesGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AboutAdd(CreateAboutDto aboutDto)
        {
            About about = new About()
            {
                Title = aboutDto.Title,
                Description = aboutDto.Description,
                ImageUrl = aboutDto.ImageUrl,
            };
            _aboutService.BusinnesAdd(about);
            return Ok("Hakkımızda Kısmı Başarılı bir şekide eklendi");
        }

        [HttpDelete("{id}")]
		public IActionResult AboutDelete(int id)
        {
            var value=_aboutService.BusinnesGetById(id);
            _aboutService.BusinnesDelete(value);
            return Ok("Hakkımızda Alanı Silindi");
        }
        [HttpPut]
        public IActionResult AboutUpdate(UpdateAboutDto aboutDto)
        {
            About about = new About()
            {
                AboutId=aboutDto.AboutId,
                Title=aboutDto.Title,
                Description=aboutDto.Description,
                ImageUrl=aboutDto.ImageUrl,
            };
            _aboutService.BusinnesUpdate(about);
            return Ok("Hakkımda Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult AboutGetById(int id)
        {
          var value= _aboutService.BusinnesGetById(id);
           return Ok(value);
        }


    }
}
