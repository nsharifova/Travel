using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class PromoController : Controller
    {
        [Microsoft.AspNetCore.Components.Route("api/[controller]")]
        [ApiController]
        public class ProController : Controller
        {
            private readonly IPromoManager _promoManager;

            public ProController(IPromoManager PromoManager)
            {
                _promoManager = PromoManager;
            }

            [HttpGet("getall")]
            public List<Promo> GetCategories()
            {
                return _promoManager.GetAll();
            }

            [HttpPost("add")]
            public Promo Add(Promo promo)
            {
                _promoManager.Add(promo);
                return promo;
            }




        }
    }
}
