using EntityLayer.Entites;

namespace SignalRApi.Models
{
	public class ResultOrderDetailWithProduct
	{
		public int OrderDetailId { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Count { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }
		public int OrderId { get; set; }
	}
}
