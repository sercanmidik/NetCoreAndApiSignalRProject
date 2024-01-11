using AutoMapper;
using DtoLayer.OrderDetailDto;
using DtoLayer.OrderDto;
using EntityLayer.Entites;

namespace SignalRApi.Mapping
{
    public class OrderDetailMapping:Profile
    {
        public OrderDetailMapping()
        {
            CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
        }
    }
}
