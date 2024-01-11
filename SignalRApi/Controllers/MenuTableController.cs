using BusinessLayer.Abstract;
using DtoLayer.AboutDto;
using DtoLayer.MenuTableDto;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTableController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.BusinessMenuTableCount());
        }
		

		[HttpGet("MenuTableList")]
		public IActionResult MenuTableList()
		{
			var values = _menuTableService.BusinnesGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult MenuTableAdd(CreateMenuTableDto menuTableDto)
		{
			MenuTable menuTable = new MenuTable()
			{
				Name = menuTableDto.Name,
				Status = false
			};
			_menuTableService.BusinnesAdd(menuTable);
			return Ok("Masa Başarılı bir şekide eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult MenuTableDelete(int id)
		{
			var value = _menuTableService.BusinnesGetById(id);
			_menuTableService.BusinnesDelete(value);
			return Ok("Masa Alanı Silindi");
		}
		[HttpPut]
		public IActionResult MenuTableUpdate(UpdateMenuTableDto menuTableDto)
		{
			MenuTable menuTable = new MenuTable()
			{
				MenuTableId= menuTableDto.MenuTableId,
				Name = menuTableDto.Name,
				Status = false
			};
			_menuTableService.BusinnesUpdate(menuTable);
			return Ok("Masa Alanı Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult MenuTableGetById(int id)
		{
			var value = _menuTableService.BusinnesGetById(id);
			return Ok(value);
		}
		[HttpGet("MenuTableChange/{tableNumber}")]
		public IActionResult MenuTableChange(string tableNumber)
		{
			_menuTableService.BusinessMenuTableChange(tableNumber);
			return Ok($"{tableNumber} Masanın Durumu Değişti");
		}

		[HttpGet("MenuTablePassiveList")]
		public IActionResult MenuTablePassiveList()
		{
			var values = _menuTableService.BusinessGetMenuTablesPassive();
			return Ok(values);
		}

	}
}
