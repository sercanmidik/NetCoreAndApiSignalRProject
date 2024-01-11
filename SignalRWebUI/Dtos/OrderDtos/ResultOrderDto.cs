﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRWebUI.Dtos.OrderDtos
{
	public class ResultOrderDto
	{
		public int OrderId { get; set; }
		public string TableNumber { get; set; }
		public string Description { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
