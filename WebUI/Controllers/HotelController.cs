using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebAPI.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        private readonly IHotelManager _hotelManager;

        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        [HttpGet("getall")]
        public List<Hotel> GetCategories()
        {
            return _hotelManager.GetAll();
        }

        [HttpPost("add")]
        public Hotel Add(Hotel hotel)
        {
            _hotelManager.Add(hotel);
            return hotel;
        }




    }
}
