using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.ProductDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper  _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet("GetMaxPriceProductName")]
        public IActionResult GetMaxPriceProductName()
        {
            return Ok(_productService.MaxPriceProductName());
        }
        [HttpGet("GetMinPriceProductName")]
        public IActionResult GetMinPriceProductName()
        {
            return Ok(_productService.MinPriceProductName());
        }
        [HttpGet("GetHamburgerCategoryAvgPrice")]
        public IActionResult GetHamburgerCategoryAvgPrice()
        {
            return Ok(_productService.BusinnessGetCategoryAvgPrice(1));
        }
        [HttpGet("GetPastaCategoryAvgPrice")]
        public IActionResult GetPastaCategoryAvgPrice()
        {
            return Ok(_productService.BusinnessGetCategoryAvgPrice(2));
        }
        [HttpGet("GetSaladCategoryAvgPrice")]
        public IActionResult GetSaladCategoryAvgPrice()
        {
            return Ok(_productService.BusinnessGetCategoryAvgPrice(3));
        }
        [HttpGet("GetSweetCategoryAvgPrice")]
        public IActionResult GetSweetCategoryAvgPrice()
        {
            return Ok(_productService.BusinnessGetCategoryAvgPrice(4));
        }
        [HttpGet("GetDrinkCategoryAvgPrice")]
        public IActionResult GetDrinkCategoryAvgPrice()
        {
            return Ok(_productService.BusinnessGetCategoryAvgPrice(5));
        }
        [HttpGet("GetHamburgerCategoryProductCount")]
        public IActionResult GetHamburgerCategoryProductCount()
        {
            return Ok(_productService.BusinnessProductCountByCategoryName(1));
        }
        [HttpGet("GetProductMaxPrice")]
        public IActionResult GetProductMaxPrice()
        {
            return Ok(_productService.BusinessMaxProductPrice());
        }
        [HttpGet("GetProductMinPrice")]
        public IActionResult GetProductMinPrice()
        {
            return Ok(_productService.BusinessMinProductPrice());
        }
        [HttpGet("GetProductAvgPrice")]
        public IActionResult GetProductAvgPrice()
        {
            return Ok(_productService.BusinessProductAvgPrice());
        }
        [HttpGet("GetDrinkCategoryProductCount")]
        public IActionResult GetDrinkCategoryProductCount()
        {
            return Ok(_productService.BusinnessProductCountByCategoryName(5));
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory() 
        {
          List<Product> products=_productService.BusinessGetProductWithCategories();
            List<ResultProductWithCategoryDto> mappedResponse = _mapper.Map<List<ResultProductWithCategoryDto>>(products);
            for (int i = 0; i < mappedResponse.Count; i++)
            {
                mappedResponse[i].CategoryName = products[i].Category.CategoryName;
            }
            return Ok(mappedResponse);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.BusinessProductCount());
        }

        [HttpGet]
        public IActionResult ProductGetAll()
        {
            var products = _productService.BusinnesGetListAll();
            var values = _mapper.Map<List<ResultProductDto>>(products);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult ProductAdd(CreateProductDto productDto)
        {
            var value = _mapper.Map<Product>(productDto);
            _productService.BusinnesAdd(value);
            return Ok("Ürün Başarılı şekilde Eklendi");
        }
        [HttpPut]
        public IActionResult ProductUpdate(UpdateProductDto productDto)
        {
            var value = _mapper.Map<Product>(productDto);
            _productService.BusinnesUpdate(value);
            return Ok("Ürün Başarılı şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult ProductDelete(int id)
        {
            var value=_productService.BusinnesGetById(id);
            _productService.BusinnesDelete(value);
            return Ok("Ürün Başarılı şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult ProductGetById(int id) 
        {
            var value = _productService.BusinnesGetById(id);
            return Ok(value);   
        }
    }
}
