using UdemyNET7Learn.Utility;

namespace UdemyNET7Learn.Models
{
    public class KiralamaRepository : Repository<Kiralama>, IKiralamaRepository
    {
        private UdemyAppDbContext _context;
        public KiralamaRepository(UdemyAppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Guncelle(Kiralama kiralama)
        {
            _context.Update(kiralama);
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }
    }
}
