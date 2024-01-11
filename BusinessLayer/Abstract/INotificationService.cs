using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface INotificationService:IGenericService<Notification>
	{
		int BusinessNotificationCountByStatusFalse();
		List<Notification> BusinnessGetAllNotificationByFalse();
		void BusinessNotificationChange(int id);
	}
}
