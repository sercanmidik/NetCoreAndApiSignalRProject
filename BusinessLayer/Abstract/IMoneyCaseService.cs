using EntityLayer.Entites;

namespace BusinessLayer.Abstract
{
    public interface IMoneyCaseService : IGenericService<MoneyCase>
    {
        decimal BusinessTotalMoneyCaseAmount();
    }

}
