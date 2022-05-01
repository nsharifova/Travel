using Business.Abstract;
using EducalProjectT210.Helpers;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class SliderController : Controller
    {

        private readonly ISliderManager _sliderManager;
        private readonly IWebHostEnvironment _environment;

        public SliderController(ISliderManager sliderManager, IWebHostEnvironment environment)
        {
            _sliderManager = sliderManager;
            _environment = environment;
        }

        // GET: SliderController
        public ActionResult Index()
        {
            return View(_sliderManager.GetAll());
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int id)
        {
            return View(_sliderManager.Get(id));
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
            var slider = _sliderManager.GetAll();
          
   
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Slider collection, IFormFile Image)
        {
            string photoName = PictureHelper.UploadPicture(Image, _environment);
            collection.PhotoUrl = photoName;
       
            _sliderManager.Add(collection);
            return RedirectToAction(nameof(Index));
        }



        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_sliderManager.Get(id));
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Slider collection, IFormFile Image, string OldPhoto)
        {
               try
            {

                if (Image != null)
                {
                    string photoName = PictureHelper.UploadPicture(Image, _environment);
                    collection.PhotoUrl = photoName;
                }
                _sliderManager.Update(collection);

            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SliderController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var selectedSlider = _sliderManager.Get(id.Value);

            if (selectedSlider == null) return NotFound();

            return View(selectedSlider);
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Slider collection)
        {
            if (id == null) return NotFound();
            if (collection == null) return NotFound();
            try
            {
                _sliderManager.Remove(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
