using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.FeatureDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureGetAll()
        {
            var values=_mapper.Map<List<ResultFeatureDto>>(_featureService.BusinnesGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult FeatureAdd(CreateFeatureDto featureDto) 
        {
            var value = _mapper.Map<Feature>(featureDto);
            _featureService.BusinnesAdd(value);
            return Ok("İçerikler Başarılı şekilde Eklendi");
        }
        [HttpPut]
        public IActionResult FeatureUpdate(UpdateFeatureDto featureDto)
        {
            var value=_mapper.Map<Feature>(featureDto);
            _featureService.BusinnesUpdate(value);
            return Ok("İçerikler Başarılı şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult FeatureDelete(int id)
        {
            var value=_featureService.BusinnesGetById(id);
            _featureService.BusinnesDelete(value);
            return Ok("İçerikler Başarılı şekilde Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult FeatureGetById(int id)
        {
            var value = _featureService.BusinnesGetById(id);
            return Ok(value);
        }
    }
}
