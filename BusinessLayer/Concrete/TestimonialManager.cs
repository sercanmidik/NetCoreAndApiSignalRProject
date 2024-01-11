using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void BusinnesAdd(Testimonial entity)
        {
            _testimonialDal.Add(entity);    
        }

        public void BusinnesDelete(Testimonial entity)
        {
           _testimonialDal.Delete(entity);
        }

        public Testimonial BusinnesGetById(int id)
        {
           return _testimonialDal.GetById(id);
        }

        public List<Testimonial> BusinnesGetListAll()
        {
            return _testimonialDal.GetListAll();
        }

        public void BusinnesUpdate(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
