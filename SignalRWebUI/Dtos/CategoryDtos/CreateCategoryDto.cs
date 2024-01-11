using Microsoft.AspNetCore.Components.Web;

namespace SignalRWebUI.Dtos.CategoryDtos
{
	public class CreateCategoryDto
	{
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
