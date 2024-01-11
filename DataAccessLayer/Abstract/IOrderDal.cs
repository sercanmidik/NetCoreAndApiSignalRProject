using EntityLayer.Entites;

namespace DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        int TotalOrderCount();
        int ActiveOrderCount();
        decimal LastOrderPrice();
        decimal TodayTotalPrice();
        List<Order> TodayOrders();
        void OrderIdByOrderClosed(int orderId);
    }
}
