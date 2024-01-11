using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.CategoryDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.BusinessCategoryCount());
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_categoryService.BusinessCategoryActiveCount());
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_categoryService.BusinessCategoryPassiveCount());
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values=_mapper.Map<List<ResultCategoryDto>>(_categoryService.BusinnesGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CategoryCreate(CreateCategoryDto categoryDto)
        {
            var value = _mapper.Map<Category>(categoryDto);
            _categoryService.BusinnesAdd(value);
            return Ok("Kategori Başarılı bir şekide eklendi");
        }
        [HttpPut]
        public IActionResult CategoryUpdate(UpdateCategoryDto categoryDto)
        {
            var value=_mapper.Map<Category>(categoryDto);
            _categoryService.BusinnesUpdate(value);
            return Ok("Kategori Başarılı bir şekide Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult CategoryDelete(int id)
        {
            var value=_categoryService.BusinnesGetById(id);
            _categoryService.BusinnesDelete(value);
            return Ok("Kategori Başarılı bir şekide silindi");
        }
        [HttpGet("{id}")]
        public IActionResult CategoryGetById(int id)
        {
            var value=_categoryService.BusinnesGetById(id);
             return Ok(value);
        }
    }
}
