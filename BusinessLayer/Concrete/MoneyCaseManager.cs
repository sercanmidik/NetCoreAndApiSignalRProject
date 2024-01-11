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
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public decimal BusinessTotalMoneyCaseAmount()
        {
          return _moneyCaseDal.TotalMoneyCaseAmount();
        }

        public void BusinnesAdd(MoneyCase entity)
        {
            _moneyCaseDal.Add(entity);
        }

        public void BusinnesDelete(MoneyCase entity)
        {
           _moneyCaseDal.Delete(entity);
        }

        public MoneyCase BusinnesGetById(int id)
        {
            return _moneyCaseDal.GetById(id);
        }

        public List<MoneyCase> BusinnesGetListAll()
        {
            return _moneyCaseDal.GetListAll();
        }

        public void BusinnesUpdate(MoneyCase entity)
        {
            _moneyCaseDal.Update(entity);
        }
    }
}
