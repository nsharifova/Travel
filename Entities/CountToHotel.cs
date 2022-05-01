using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CountToHotel : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel? Hotel { get; set; }
        public virtual Country? Country { get; set;}
    }
}
