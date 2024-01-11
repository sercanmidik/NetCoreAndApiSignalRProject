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
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        private readonly SignalRContext _context;
        public EfMoneyCaseDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public decimal TotalMoneyCaseAmount()
        {
            return _context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
        }
    }
}
