using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void BusinnesAdd(T entity);
        void BusinnesDelete(T entity);
        void BusinnesUpdate(T entity);
        T BusinnesGetById(int id);
        List<T> BusinnesGetListAll();
    }
}
