using UdemyNET7Learn.Utility;

namespace UdemyNET7Learn.Models
{
    public class KitapTuruRepository : Repository<KitapTuru>, IKitapTuruRepository
    {
        private readonly UdemyAppDbContext _context;

        public KitapTuruRepository(UdemyAppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(KitapTuru kitapTuru)
        {
            _context.KitapTurleri.Update(kitapTuru);
        }
    }
}
