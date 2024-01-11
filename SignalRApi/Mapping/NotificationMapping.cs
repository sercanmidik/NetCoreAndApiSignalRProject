using AutoMapper;
using DtoLayer.NotificationDto;
using EntityLayer.Entites;

namespace SignalRApi.Mapping
{
	public class NotificationMapping:Profile
	{
        public NotificationMapping()
        {
			CreateMap<Notification, ResultNotificationDto>().ReverseMap();
			CreateMap<Notification, GetByIdNotificationDto>().ReverseMap();
			CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
			CreateMap<Notification, CreateNotificationDto>().ReverseMap();
		}
    }
}
