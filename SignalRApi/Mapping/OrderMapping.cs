using AutoMapper;
using DtoLayer.OrderDto;
using EntityLayer.Entites;

namespace SignalRApi.Mapping
{
    public class OrderMapping:Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, ResultOrderDto>().ReverseMap().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap().ReverseMap();
            CreateMap<Order, GetOrderDto>().ReverseMap().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap().ReverseMap();
        }
    }
}
