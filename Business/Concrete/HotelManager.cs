using Business.Abstract;
using DataAccess.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HotelManager:IHotelManager
    {
        private readonly IHotelDal _dal;


        public HotelManager(IHotelDal dal)
        {
            _dal = dal;
        }

        public void Add(Hotel hotel)
        {
            Hotel ins = new()
            {
               Name= hotel.Name,
               Rating= hotel.Rating,
               Price= hotel.Price,
               Discount= hotel.Discount,
               DayNight= hotel.DayNight,
               Person= hotel.Person,
                Description = hotel.Description,
                PhotoUrl = hotel.PhotoUrl,

            };

            _dal.Add(ins);
        }

        public Hotel Get(int id)
        {
            return _dal.Get(x => x.Id == id);
        }

        public List<Hotel> GetAll()
        {
            return _dal.GetAll(null);
        }

        public void Remove(Hotel hotel)
        {
            _dal.Delete(hotel);
        }

        public void Update(Hotel hotel)
        {
            _dal.Update(hotel);
        }
    }
}
