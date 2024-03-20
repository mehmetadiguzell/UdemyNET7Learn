namespace UdemyNET7Learn.Models
{
    public interface IKitapRepository : IRepository<Kitap>
    {
        void Update(Kitap kitap);
        void Save();
    }
}
