using Business.Abstract;
using EducalProjectT210.Helpers;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class HotelController : Controller
    {
        // GET: HotelController
        private readonly IHotelManager _hotelmanager;
        private readonly IWebHostEnvironment _environment;

        public HotelController(IHotelManager hotelmanager, IWebHostEnvironment environment)
        {
            _hotelmanager = hotelmanager;
            _environment = environment;
        }

        public ActionResult Index()
        {
            return View(_hotelmanager.GetAll());
        }

        // GET: HotelController/Details/5
        public ActionResult Details(int id)
        {
            return View(_hotelmanager.Get(id));
        }

        // GET: HotelController/Create
        public ActionResult Create()
        {
            var hotel = _hotelmanager.GetAll();
            return View();
        }

        // POST: HotelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Hotel hotel, IFormFile Image)
        {
            string photoName = PictureHelper.UploadPicture(Image, _environment);
            hotel.PhotoUrl = photoName;

            _hotelmanager.Add(hotel);
            return RedirectToAction(nameof(Index));
        }


        // GET: HotelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_hotelmanager.Get(id));
        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hotel hotel, IFormFile Image,string OldPhoto)
        {
            try
            {

                if (Image != null)
                {
                    string photoName = PictureHelper.UploadPicture(Image, _environment);
                    hotel.PhotoUrl = photoName;
                }
                _hotelmanager.Update(hotel);

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
            var selectedHotel = _hotelmanager.Get(id.Value);

            if (selectedHotel == null) return NotFound();

            return View(selectedHotel);
        }

        // POST: HotelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hotel collection)
        {
            if (id == null) return NotFound();
            if (collection == null) return NotFound();
            try
            {
                _hotelmanager.Remove(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
