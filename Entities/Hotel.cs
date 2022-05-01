using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Hotel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public string Description { get; set; }
        public int Person { get; set; }
        public string? PhotoUrl { get; set; }

        public int? DayNight { get; set; } 
    }
}
