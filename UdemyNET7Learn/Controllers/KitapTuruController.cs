using Microsoft.AspNetCore.Mvc;
using UdemyNET7Learn.Models;

namespace UdemyNET7Learn.Controllers
{
    public class KitapTuruController : Controller
    {
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapTuruController(IKitapTuruRepository kitapTuruRepository)
        {
            _kitapTuruRepository = kitapTuruRepository;
        }

        public IActionResult Index()
        {
            var model = _kitapTuruRepository.GetAll();
            return View(model);
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                _kitapTuruRepository.Add(kitapTuru);
                _kitapTuruRepository.Save();
                TempData["basarili"] = "Kitap Türü Ekleme Başarılı";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Guncelle(int? id)
        {
            var values = _kitapTuruRepository.Get(u => u.Id == id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Guncelle(KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                _kitapTuruRepository.Update(kitapTuru);
                _kitapTuruRepository.Save();
                TempData["basarili"] = "Kitap Türü Güncelleme Başarılı";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Sil(int? id)
        {
            var values = _kitapTuruRepository.Get(u => u.Id == id);
            _kitapTuruRepository.Delete(values);
            _kitapTuruRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
