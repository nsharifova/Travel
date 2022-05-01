using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHotelManager
    {
        void Add(Hotel hotel);
        //void Remove(Slider slider);
        void Update(Hotel hotel);
        List<Hotel> GetAll();
        Hotel Get(int id);
        void Remove(Hotel hotel);
    }
}
