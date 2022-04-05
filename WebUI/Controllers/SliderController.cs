using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : Controller
    {
        private readonly ISliderManager _SliderManager;

        public SliderController(ISliderManager SliderManager)
        {
            _SliderManager = SliderManager;
        }

        [HttpGet("getall")]
        public List<Slider> GetCategories()
        {
            return _SliderManager.GetAll();
        }

        [HttpPost("add")]
        public Slider Add(Slider Slider)
        {
            _SliderManager.Add(Slider);
            return Slider;
        }
    }
}
