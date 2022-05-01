using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Spesification : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
