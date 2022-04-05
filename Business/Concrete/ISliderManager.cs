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
    public class SliderManager:ISliderManager
    {
        private readonly ISliderDal _dal;

        public SliderManager(ISliderDal dal)
        {
            _dal = dal;
        }


        public void Add(Slider slider)
        {
            Slider ins = new()
            {
            Title=slider.Title,
            Description=slider.Description,
            PhotoUrl=slider.PhotoUrl,

            };

            _dal.Add(ins);
          

        }

        public Slider Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Slider> GetAll()
        {
            return _dal.GetAll(null);
        }

        public void Remove(Slider slider)
        {
            throw new NotImplementedException();
        }

        public void Update(Slider slider)
        {
            throw new NotImplementedException();
        }
    }
}
