using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SpecToHotel : IEntity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int SpesificationId { get; set; }
        public virtual Hotel? Hotel { get; set; }
        public virtual Spesification? Speification { get; set; }
    }
}
