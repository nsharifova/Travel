using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contact:BaseEntity,IEntity
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }
    }
}
