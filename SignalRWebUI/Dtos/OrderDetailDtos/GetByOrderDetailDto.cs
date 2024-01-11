﻿using EntityLayer.Entites;

namespace SignalRWebUI.Dtos.OrderDetailDtos
{
	public class GetByOrderDetailDto
	{
		public int OrderDetailId { get; set; }
		public int ProductId { get; set; }
		public int Count { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }
		public int OrderId { get; set; }
	
	}
}
