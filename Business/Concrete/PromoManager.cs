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
    public class PromoManager : IPromoManager
    {
        private readonly IPromoDal _promo;

        public PromoManager(IPromoDal promo)
        {
            _promo = promo;
        }

        public void Add(Promo promo)
        {
            Promo ins = new()
            {
                Title = promo.Title,
                Description = promo.Description,
                PhotoUrl = promo.PhotoUrl,
                Id = promo.Id,
                Color=promo.Color,

            };

            _promo.Add(ins);
        }

        public Promo Get(int id)
        {
            return _promo.Get(x => x.Id == id);
        }

        public List<Promo> GetAll()
        {
            return _promo.GetAll(null);
        }


        public void Remove(Promo promo)
        {
            _promo.Delete(promo);
        }

        public void Update(Promo promo)
        {
            _promo.Update(promo);
        }
    }
}

