using Business.Abstract;
using EducalProjectT210.Helpers;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class PromoController : Controller
    {
        // GET: PromoController
        // GET: HotelController
        private readonly IPromoManager _promoManager;
        private readonly IWebHostEnvironment _environment;

        public PromoController(IPromoManager promoManager, IWebHostEnvironment environment)
        {
            _promoManager = promoManager;
            _environment = environment;
        }

        public ActionResult Index()
        {
            var promo = _promoManager.GetAll();
            if (promo.Count != 0)
            {
                ViewBag.Sayi = 1;
            }
            else
            {
                ViewBag.Sayi = 0;
            }

            return View(promo);
        }

        // GET: HotelController/Details/5
        public ActionResult Details(int id)
        {
            return View(_promoManager.Get(id));
        }

        // GET: HotelController/Create
        public ActionResult Create()
        {
            var hotel = _promoManager.GetAll();
            return View();
        }

        // POST: HotelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Promo promo, IFormFile Image)
        {
            string photoName = PictureHelper.UploadPicture(Image, _environment);
            promo.PhotoUrl = photoName;

            _promoManager.Add(promo);
            return RedirectToAction(nameof(Index));
        }


        // GET: HotelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_promoManager.Get(id));
        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Promo promo, IFormFile Image, string OldPhoto)
        {
            try
            {

                if (Image != null)
                {
                    string photoName = PictureHelper.UploadPicture(Image, _environment);
                    promo.PhotoUrl = photoName;
                }
                _promoManager.Update(promo);

            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: HotelController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var selectedPromo = _promoManager.Get(id.Value);

            if (selectedPromo == null) return NotFound();

            return View(selectedPromo);
        }

        // POST: HotelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Promo promo)
        {
            if (id == null) return NotFound();
            if (promo == null) return NotFound();
            try
            {
                _promoManager.Remove(promo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
