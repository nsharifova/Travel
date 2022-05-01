using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CategoryToHotel : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int HotelId { get; set; }
        public virtual Hotel? Hotel { get; set; }    
        public virtual Category? Category { get; set; }
    }
}
