using EntityLayer.Entites;

namespace BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        int BusinessTotalOrderCount();
        int BusinessActiveOrderCount();
        decimal BusinessLastOrderPrice();
        decimal BusinessTodayTotalPrice();
		List<Order> BusinnessTodayOrders();
        void BusinessOrderIdByOrderClosed(int orderId);
	}
}
