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
	public class NotificationManager : INotificationService
	{
		private readonly INotificationDal _notificationDal;

		public NotificationManager(INotificationDal notificationDal)
		{
			_notificationDal = notificationDal;
		}

		public void BusinessNotificationChange(int id)
		{
			_notificationDal.NotificationChange(id);
		}

		public int BusinessNotificationCountByStatusFalse()
		{
			return _notificationDal.NotificationCountByStatusFalse();
		}

		public void BusinnesAdd(Notification entity)
		{
			_notificationDal.Add(entity);
		}

		public void BusinnesDelete(Notification entity)
		{
			_notificationDal.Delete(entity);
		}

		public Notification BusinnesGetById(int id)
		{
			return _notificationDal.GetById(id);
		}

		public List<Notification> BusinnesGetListAll()
		{
			return _notificationDal.GetListAll();
		}

		public List<Notification> BusinnessGetAllNotificationByFalse()
		{
			return _notificationDal.GetAllNotificationByFalse();
		}

		public void BusinnesUpdate(Notification entity)
		{
			_notificationDal.Update(entity);
		}
	}
}
