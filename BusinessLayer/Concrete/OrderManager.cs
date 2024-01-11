using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public int BusinessActiveOrderCount()
        {
          return _orderDal.ActiveOrderCount();
        }

        public decimal BusinessLastOrderPrice()
        {
           return _orderDal.LastOrderPrice();
        }

		public void BusinessOrderIdByOrderClosed(int orderId)
		{
            _orderDal.OrderIdByOrderClosed(orderId);
		}

		public decimal BusinessTodayTotalPrice()
        {
           return _orderDal.TodayTotalPrice();
        }

        public int BusinessTotalOrderCount()
        {
           return _orderDal.TotalOrderCount();
        }

        public void BusinnesAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void BusinnesDelete(Order entity)
        {
           _orderDal.Delete(entity);
        }

        public Order BusinnesGetById(int id)
        {
           return _orderDal.GetById(id);
        }

        public List<Order> BusinnesGetListAll()
        {
            return _orderDal.GetListAll();
        }

		public List<Order> BusinnessTodayOrders()
		{
			return _orderDal.TodayOrders();
		}

		public void BusinnesUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}