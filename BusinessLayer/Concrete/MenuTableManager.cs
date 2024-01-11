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
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public int BusinessActiveMenuTableCount()
        {
            return _menuTableDal.ActiveMenuTableCount();
        }

        public int BusinessMenuTableCount()
        {
           return _menuTableDal.MenuTableCount();
        }

        public int BusinessPassiveMenuTableCount()
        {
            return _menuTableDal.PassiveMenuTableCount();
        }

        public void BusinnesAdd(MenuTable entity)
        {
           _menuTableDal.Add(entity);
        }

        public void BusinnesDelete(MenuTable entity)
        {
            _menuTableDal.Delete(entity);
        }

        public MenuTable BusinnesGetById(int id)
        {
           return _menuTableDal.GetById(id);  
        }

        public List<MenuTable> BusinnesGetListAll()
        {
            return _menuTableDal.GetListAll();
        }

        public void BusinnesUpdate(MenuTable entity)
        {
            _menuTableDal.Update(entity);   
        }

		public void BusinessMenuTableChange(string tableNumber)
		{
			_menuTableDal.MenuTableChange(tableNumber);
		}

		public List<MenuTable> BusinessGetMenuTablesPassive()
		{
			return _menuTableDal.GetMenuTablesPassive();
		}
	}
}
