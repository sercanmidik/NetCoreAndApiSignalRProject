﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRWebUI.Dtos.OrderDtos
{
	public class CreateOrderDto
	{
		public string TableNumber { get; set; }
		public string Description { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalPrice { get; set; }

	}
}
