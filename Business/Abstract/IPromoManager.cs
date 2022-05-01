using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPromoManager
    {
        void Add(Promo promo);
        void Update(Promo promo);
        List<Promo> GetAll();
        Promo Get(int id);
        void Remove(Promo promo);
    }
}
