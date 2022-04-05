using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Package:BaseEntity,IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public decimal Price { get; set; }
        public string Country { get; set; }
        public int Person { get; set; }
        public string PhotoUrl { get; set; }

        public string DayNight { get; set; }

    }
}
