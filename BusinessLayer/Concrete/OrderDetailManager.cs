using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.OrderDetailDto;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void BusinessCountPlus(CountPlusDetailDto cpDto)
        {
            _orderDetailDal.CountPlus(cpDto);
        }

        public bool BusinessOrderIdInProductId(CountPlusDetailDto cpdDto)
        {
           return _orderDetailDal.OrderIdInProductId(cpdDto);
        }

        public void BusinnesAdd(OrderDetail entity)
        {
            _orderDetailDal.Add(entity);
        }

        public void BusinnesDelete(OrderDetail entity)
        {
            _orderDetailDal.Delete(entity);
        }

        public OrderDetail BusinnesGetById(int id)
        {
            return _orderDetailDal.GetById(id);
        }

		public List<OrderDetail> BusinnesGetByIdOrderList(int id)
		{
            return _orderDetailDal.GetByIdOrderList(id);
		}

		public List<OrderDetail> BusinnesGetListAll()
        {
            return _orderDetailDal.GetListAll();
        }

        public void BusinnesUpdate(OrderDetail entity)
        {
            _orderDetailDal.Update(entity);
        }
    }
}