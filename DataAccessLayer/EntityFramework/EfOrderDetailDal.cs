using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.OrderDetailDto;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
		private readonly SignalRContext _context;
        public EfOrderDetailDal(SignalRContext context) : base(context)
        {
			_context = context;
        }

        public void CountPlus(CountPlusDetailDto cpDto)
        {
            var value = _context.OrderDetails.Where(x => x.ProductId == cpDto.ProductId && x.OrderId == cpDto.OrderId).FirstOrDefault();
            if (value != null)
            {
                value.Count++;
                _context.SaveChanges();
            }
        }

        public List<OrderDetail> GetByIdOrderList(int id)
		{
			return _context.OrderDetails.Where(x=>x.OrderId==id).ToList();
		}

        public bool OrderIdInProductId(CountPlusDetailDto cpdDto)
        {
            return _context.OrderDetails.Where(x=>x.ProductId==cpdDto.ProductId && x.OrderId==cpdDto.OrderId).Any();
        }
    }
}
