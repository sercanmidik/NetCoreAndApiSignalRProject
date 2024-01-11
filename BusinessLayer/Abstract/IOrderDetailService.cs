using DtoLayer.OrderDetailDto;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderDetailService:IGenericService<OrderDetail>
    {
		List<OrderDetail> BusinnesGetByIdOrderList(int id);
        bool BusinessOrderIdInProductId(CountPlusDetailDto cpdDto);
        void BusinessCountPlus(CountPlusDetailDto cpDto);

    }
}
