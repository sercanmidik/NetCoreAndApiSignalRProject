using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		private readonly SignalRContext _context;
		public EfNotificationDal(SignalRContext context) : base(context)
		{
			_context = context;
		}

		public List<Notification> GetAllNotificationByFalse()
		{
			return _context.Notifications.Where(x => x.Status == false).ToList();
		}

		public void NotificationChange(int id)
		{
			var value = _context.Notifications.Where(x => x.NotificationId == id).FirstOrDefault();
			if (value?.Status == true)
			{
				value.Status = false;
				_context.Notifications.Update(value);
			}
			else
			{
				value.Status = true;
				_context.Notifications.Update(value);
			}
			_context.SaveChanges();

		}

		public int NotificationCountByStatusFalse()
		{
		 return	_context.Notifications.Where(x => x.Status == false).Count();
		}
	}
}
