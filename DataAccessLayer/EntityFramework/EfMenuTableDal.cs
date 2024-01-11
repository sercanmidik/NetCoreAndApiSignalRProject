using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;

namespace DataAccessLayer.EntityFramework
{
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        private readonly SignalRContext _context;
        public EfMenuTableDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int ActiveMenuTableCount()
        {
            return _context.MenuTables.Where(x => x.Status == true).Count();
        }

		public List<MenuTable> GetMenuTablesPassive()
		{
			return _context.MenuTables.Where(x=>x.Status==false).ToList();
		}

		public void MenuTableChange(string tableNumber)
		{
           var value= _context.MenuTables.Where(x => x.Name== tableNumber).FirstOrDefault();
            if (value!=null)
            {
                if(value.Status==true)
                {
					value.Status = false;
				}
                else
                {
                    value.Status = true;
                }
               
                _context.SaveChanges();
            }
		}

		public int MenuTableCount()
        {
            return _context.MenuTables.Count();
        }

        public int PassiveMenuTableCount()
        {
            return _context.MenuTables.Where(x => x.Status == false).Count();
        }
    }
}
