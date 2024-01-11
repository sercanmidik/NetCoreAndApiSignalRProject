using EntityLayer.Entites;

namespace BusinessLayer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
		void BusinessChangeStatus(int id);
		List<Discount> BusinessGetDiscountTrueTopThree();
	}

}
