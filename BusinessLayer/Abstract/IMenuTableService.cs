using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMenuTableService : IGenericService<MenuTable>
    {
        int BusinessMenuTableCount();
        int BusinessActiveMenuTableCount();
        int BusinessPassiveMenuTableCount();
        void BusinessMenuTableChange(string tableNumber);
		List<MenuTable> BusinessGetMenuTablesPassive();
	}
}
