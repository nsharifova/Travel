using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISliderManager _slider;
        private readonly IHotelManager _hotelManager;
        private readonly IPromoManager _promoManager;


        public HomeController(ILogger<HomeController> logger, ISliderManager slider, IHotelManager hotelManager, IPromoManager promoManager)
        {
            _logger = logger;
            _slider = slider;
            _hotelManager = hotelManager;
            _promoManager = promoManager;
        }

        public IActionResult Index()
        {

            HomeVM vm = new()
            {
                Slider = _slider.GetAll(),
                Hotel=_hotelManager.GetAll(),
                Promo=_promoManager.GetAll().FirstOrDefault(),
            

            };
            return View(vm);
        }

        [HttpPost]
      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}