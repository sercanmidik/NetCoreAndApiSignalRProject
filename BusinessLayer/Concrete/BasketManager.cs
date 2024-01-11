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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public List<Basket> BusinessGetBasketByMenuTableNumber(int tableId)
        {
            return _basketDal.GetBasketByMenuTableNumber(tableId);
        }

        public void BusinnesAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void BusinnesDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public Basket BusinnesGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public List<Basket> BusinnesGetListAll()
        {
            return _basketDal.GetListAll();
        }

        public void BusinnesUpdate(Basket entity)
        {
            _basketDal.Update(entity);
        }
    }
}
