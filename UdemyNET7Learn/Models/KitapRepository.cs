using UdemyNET7Learn.Utility;

namespace UdemyNET7Learn.Models
{
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        private readonly UdemyAppDbContext _context;

        public KitapRepository(UdemyAppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Kitap kitap)
        {
            _context.Kitaplar.Update(kitap);
        }
    }
}
