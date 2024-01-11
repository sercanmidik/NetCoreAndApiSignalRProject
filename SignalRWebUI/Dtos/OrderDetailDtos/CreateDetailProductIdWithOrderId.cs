namespace SignalRWebUI.Dtos.OrderDetailDtos
{
    public class CreateDetailProductIdWithOrderId
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
