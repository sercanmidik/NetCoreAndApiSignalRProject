using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Migrations;
using DtoLayer.BasketDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("tableId")]
        public IActionResult GetBasketByMenuTableId(int tableId)
        {
          var values= _basketService.BusinessGetBasketByMenuTableNumber(tableId);
            return Ok(values);
        }
        [HttpGet("Id")]
        public IActionResult BasketListByMenuWithProductName(int Id)
        {
            using var context = new SignalRContext();
            var values=context.Baskets.Include(x=>x.Product).Where(y=>y.MenuTableId==Id).Select(z=>new ResultBasketWithProduct
            {
                BasketId=z.BasketId,
                Count=z.Count,
                MenuTableId=Id,
                Price=z.Price,
                ProductId=z.ProductId,
                ProductName=z.Product.ProductName,
                TotalPrice=z.TotalPrice,
            }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult BasketAdd(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.BusinnesAdd(new Basket
            {
                ProductId = createBasketDto.ProductId,
                Count = 1,
                MenuTableId = 4,
                Price = context.Products.Where(x => x.ProductId == createBasketDto.ProductId).Select(x => x.Price).FirstOrDefault(),
                TotalPrice = 0,

            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult BasketRemove(int id)
        {
            var value=_basketService.BusinnesGetById(id);
            _basketService.BusinnesDelete(value);
            return Ok("Sepetteki Ürün Silindi");
        }
    }
}
