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
	public class MessageManager : IMessageService
	{
		private readonly IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void BusinnesAdd(Message entity)
		{
			_messageDal.Add(entity);
		}

		public void BusinnesDelete(Message entity)
		{
			_messageDal.Delete(entity);
		}

		public Message BusinnesGetById(int id)
		{
			return _messageDal.GetById(id);
		}

		public List<Message> BusinnesGetListAll()
		{
			return _messageDal.GetListAll();
		}

		public void BusinnesUpdate(Message entity)
		{
			_messageDal.Update(entity);	
		}
	}
}
