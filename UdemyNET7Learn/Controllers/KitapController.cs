using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyNET7Learn.Models;
using UdemyNET7Learn.Utility;

namespace UdemyNET7Learn.Controllers
{
    public class KitapController : Controller
    {
        private readonly IKitapRepository _kitapRepository;
        private readonly IKitapTuruRepository _kitapTuruRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public KitapController(IKitapRepository kitapRepository, IKitapTuruRepository kitapTuruRepository, IWebHostEnvironment webHostEnvironment)
        {
            _kitapRepository = kitapRepository;
            _kitapTuruRepository = kitapTuruRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Kitap> model = _kitapRepository.GetAll(includeProps: "KitapTuru").ToList();
            return View(model);
        }
        // Get
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> KitapTuruList = _kitapTuruRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.TurAdi,
                    Value = k.Id.ToString()
                });
            ViewBag.KitapTuruList = KitapTuruList;

            if (id == null || id == 0)
            {
                // ekle
                return View();
            }
            else
            {
                // guncelleme
                Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);  // Expression<Func<T, bool>> filtre
                if (kitapVt == null)
                {
                    return NotFound();
                }
                return View(kitapVt);
            }

        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult EkleGuncelle(Kitap kitap, IFormFile? file)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string kitapPath = Path.Combine(wwwRootPath, @"img");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(kitapPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    kitap.ResimUrl = @"\img\" + file.FileName;
                }

                if (kitap.Id == 0)
                {
                    _kitapRepository.Add(kitap);
                    TempData["basarili"] = "Yeni Kitap başarıyla oluşturuldu!";
                }
                else
                {
                    _kitapRepository.Update(kitap);
                    TempData["basarili"] = "Kitap güncelleme başarılı!";
                }

                _kitapRepository.Save(); // SaveChanges() yapmazsanız bilgiler veri tabanına eklenmez!			
                return RedirectToAction("Index", "Kitap");
            }
            return View();
        }
        public IActionResult Guncelle(int? id)
        {
            var values = _kitapRepository.Get(u => u.Id == id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Guncelle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _kitapRepository.Update(kitap);
                _kitapRepository.Save();
                TempData["basarili"] = "Kitap  Güncelleme Başarılı";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Sil(int? id)
        {
            var values = _kitapRepository.Get(u => u.Id == id);
            _kitapRepository.Delete(values);
            _kitapRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
