using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ContactDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.BusinnesGetListAll());
           return Ok(values);
        }

        [HttpPost]
        public IActionResult ContactAdd(CreateContactDto contactDto)
        {
            var value=_mapper.Map<Contact>(contactDto);
            _contactService.BusinnesAdd(value);
            return Ok("İçerik Başarılı şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult ContactDelete(int id) 
        {
            var value=_contactService.BusinnesGetById(id);
            _contactService.BusinnesDelete(value);
            return Ok("İçerik Başarılı şekilde Silindi");
        }
        [HttpPut]
        public IActionResult ContactUpdate(UpdateContactDto contactDto)
        {
            var value = _mapper.Map<Contact>(contactDto);
            _contactService.BusinnesUpdate(value);
            return Ok("İçerik Başarılı şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult ContactGetById(int id)
        {
            var value = _contactService.BusinnesGetById(id);
            return Ok(value);
        }

    }
}
