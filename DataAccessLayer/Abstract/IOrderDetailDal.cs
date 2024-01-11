using DtoLayer.OrderDetailDto;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IOrderDetailDal : IGenericDal<OrderDetail>
    {
        List<OrderDetail> GetByIdOrderList(int id);
        bool OrderIdInProductId(CountPlusDetailDto cpdDto);
        void CountPlus(CountPlusDetailDto cpDto);
    }
}
